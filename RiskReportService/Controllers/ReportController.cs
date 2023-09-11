using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RiskReportService.Contracts;
using RiskReportService.Models;

namespace RiskReportService.Controllers
{
    [ApiController]
    [Route("Report")]
    public class ReportController : Controller
    {
        private readonly HttpClient _httpClientPatient;
        private readonly IAgeCalculator _ageCalculator;
        private readonly ITriggerTermsFinder _triggerTermsFinder;
        private readonly IDiabetesRiskLevelFinder _diabetesRiskLevelFinder;

        public PatientViewModel patient { get; set; }
        public List<NoteViewModel> notes { get; set; }

        public ReportController(IHttpClientFactory httpClientFactory,
            IAgeCalculator ageCalculator,
            ITriggerTermsFinder triggerTermsFinder,
            IDiabetesRiskLevelFinder diabetesRiskLevelFinder)
        {
            _httpClientPatient = httpClientFactory.CreateClient();
            _httpClientPatient.BaseAddress = new Uri("http://patientservice:80");
            _ageCalculator = ageCalculator;
            _triggerTermsFinder = triggerTermsFinder;
            _diabetesRiskLevelFinder = diabetesRiskLevelFinder;
        }

        /// <summary>
        /// Method to generate a Diabetes Risk Report for a given patient, showing patient's name, age and sex, the trigger terms and the risk level.
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
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
                    var content = await response.Content.ReadAsStringAsync();
                    patient = JsonConvert.DeserializeObject<PatientViewModel>(content);

                    // Calculate patient's age
                    int age = _ageCalculator.CalculateAge(patient.DateOfBirth);

                    // Count tne number of distinct trigger terms in all notes for the patient and list them
                    var triggerTerms = _triggerTermsFinder.CountTriggerTerms(patientId);
                    Console.WriteLine($"Triggers number = {triggerTerms.Result.TriggersCount}");
                    Console.WriteLine($"First trigger found = {triggerTerms.Result.TriggerTerms[0]}");

                    // Determine Diabetes risk level based on age, sex and trigger terms number
                    var riskLevelTask = _diabetesRiskLevelFinder.DetermineRiskLevel(triggerTerms.Result.TriggersCount, age, patient.Sex);

                    // Create the report
                    var report = new Report
                    {
                        PatientName = patient.FirstName + " " + patient.LastName,
                        Age = age,
                        Sex = patient.Sex,
                        RiskLevel = riskLevelTask.Result,
                        triggerTermList = triggerTerms.Result
                    };

                    Console.WriteLine("Report created = " + report);
                    return Ok(report);
                }
            }
            catch (Exception ex)
            {
                return BadRequest("An error occurred : " + ex.Message);
            }
        }
    }
}