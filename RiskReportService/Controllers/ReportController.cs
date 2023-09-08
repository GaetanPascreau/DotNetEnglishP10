﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RiskReportService.Data;
using RiskReportService.Models;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;

namespace RiskReportService.Controllers
{
    [ApiController]
    [Route("Report")]
    public class ReportController : Controller
    {
        private readonly HttpClient _httpClientPatient;
        private readonly HttpClient _httpClientNote;

        public PatientViewModel patient { get; set; }
        public List<NoteViewModel> notes { get; set; }

        public ReportController(IHttpClientFactory httpClientFactory)
        {
            _httpClientPatient = httpClientFactory.CreateClient();
            _httpClientPatient.BaseAddress = new Uri("http://patientservice:80");
            _httpClientNote = httpClientFactory.CreateClient();
            _httpClientNote.BaseAddress = new Uri("http://noteservice:80");
        }

        // GET Report/{patientId}
        [HttpGet("{patientId}")]
        public async Task<ActionResult<Report>> GenerateRiskReport(int patientId)
        {
            try
            {
                // Get the patient with the given patientId, using PatientDemographicsService
                var response = await _httpClientPatient.GetAsync($"patients/{patientId}");

                if (!response.IsSuccessStatusCode)
                {
                    return NotFound($"Patient with id = {patientId} was not found.");
                }
                else
                {
                    Console.WriteLine("Status code after retrieving patient is OK");
                    var content = await response.Content.ReadAsStringAsync();
                    patient = JsonConvert.DeserializeObject<PatientViewModel>(content);

                    // CAlculate patient's age
                    int age = CalculateAge(patient.DateOfBirth);

                    var triggersNumber = CountTriggerTerms(patientId);
                    Console.WriteLine($"TriggersNumber before calling DetermineRiskLEvel() = {triggersNumber}"); //shows 0 ! but should be 3 for patient 1
                    var riskLevelTask = DetermineRiskLevel(await triggersNumber, age, patient).Result.Value;

                    var report = new Report
                    {
                        PatientName = patient.FirstName + " " + patient.LastName,
                        Age = age,
                        Sex = patient.Sex,
                        RiskLevel = riskLevelTask
                    };

                    Console.WriteLine("Report created = " + report);
                    return report;
                }
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred : " + ex.Message);
            }
        }

        [HttpGet("Report/Age/{dateOfBirth}")]
        public int CalculateAge(DateTime dateOfBirth)
        {
            int YearOfBirth = dateOfBirth.Year;
            int CurrentYear = DateTime.Now.Year;
            int Age = 0;

            if (dateOfBirth.Month > DateTime.Now.Month || (dateOfBirth.Month == DateTime.Now.Month && dateOfBirth.Day > DateTime.Now.Day))
            {
                Age = CurrentYear - YearOfBirth - 1;
            }
            else
            {
                Age = CurrentYear - YearOfBirth;
            }

            Console.WriteLine("My age is " + Age + " years.");
            return Age;
        }

        [HttpGet("Report/TriggerTerms")]
        public async Task<int> CountTriggerTerms(int patientId)
        {
            try
            {
                List<string> triggers = new List<string>
                {
                    "Hemoglobin A1C", "Microalbumin", "Body Height", "Body Weight", "Smoker", "Abnormal", "Cholesterol", "Dizziness", "Relapse",
                    "Reaction", "Antibodies"
                };

                var response = await _httpClientNote.GetAsync($"api/Notes/patient/{patientId}/notes");
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Content = " + content);

                notes = JsonConvert.DeserializeObject<List<NoteViewModel>>(content);

                if (notes == null)
                {
                    return 0;
                }

                // Create a dictionnary to store the ocurences
                Dictionary<string, int> occurences = new Dictionary<string, int>();

                foreach (string trigger in triggers)
                {
                    bool triggerFound = false;

                    foreach (var note in notes)
                    {
                        if (Regex.IsMatch(note.NoteContent, $@"\b{Regex.Escape(trigger)}\b", RegexOptions.IgnoreCase))
                        {
                            triggerFound = true;
                            break; // Exit the inner loop as soon as the trigger is found
                        }
                    }

                    int count = triggerFound ? 1 : 0; // Count 1 if the trigger was found, otherwise count 0

                    occurences[trigger] = count;
                    Console.WriteLine($"trigger = {trigger} : count = {count}");
                }

                // Calculate the total count of occurences
                int totalCount = occurences.Values.Sum();
                Console.WriteLine("Number of trigger terms found  = " + totalCount);

                return totalCount;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred : " + ex.Message);
                return 0;
            }
        }

        [HttpGet("Report/RiskLevel")]
        public async Task<ActionResult<string>> DetermineRiskLevel(int triggersNumber, int age, PatientViewModel patient)
        {
            try
            {
                Console.WriteLine($"age calculated in DetermineRiskLevel = {age}");
                var riskLevel = "";
                Console.WriteLine($"TriggersNumber used in DetermineRiskLevel = {triggersNumber}");

                if (age <= 30)
                {
                    if (patient.Sex == 'M')
                    {
                        if (triggersNumber >= 5)
                        {
                            riskLevel = "Early Onset";
                        }
                        else if (triggersNumber >= 3)
                        {
                            riskLevel = "In Danger";
                        }
                        else
                        {
                            riskLevel = "None";
                        }
                    }
                    else if (patient.Sex == 'F')
                    {
                        if (triggersNumber >= 7)
                        {
                            riskLevel = "Early Onset";
                        }
                        else if (triggersNumber >= 4)
                        {
                            riskLevel = "In Danger";
                        }
                        else
                        {
                            riskLevel = "None";
                        }
                    }
                }
                else if (age > 30)
                {
                    if (triggersNumber >= 8)
                    {
                        riskLevel = "Early Onset";
                    }
                    else if (triggersNumber >= 6)
                    {
                        riskLevel = "In Danger";
                    }
                    else if (triggersNumber >= 2)
                    {
                        riskLevel = "Borderline";
                    }
                    else
                    {
                        riskLevel = "None";
                    }
                }

                Console.WriteLine($"RiskLevel determined in DetermineRiskLevel = {riskLevel}");
                return riskLevel;
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred : " + ex.Message);
            }
        }
    }
}
