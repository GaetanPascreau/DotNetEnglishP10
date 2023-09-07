using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RiskReportService.Models;
using System.Net.Http;
using System.Text;

namespace RiskReportService.Controllers
{
    [ApiController]
    [Route("Report")]
    public class ReportController : Controller
    {
        private readonly HttpClient _httpClientPatient;
        private readonly HttpClient _httpClientNote;

        public PatientViewModel patient { get; set; }

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
            var response = await _httpClientPatient.GetAsync($"patients/{patientId}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                patient = JsonConvert.DeserializeObject<PatientViewModel>(content);

         
                // re-think everything !
                var report = new Report
                {
                    PatientName = patient.FirstName + " " + patient.LastName,
                    Age = CalculateAge(patient.DateOfBirth),
                    Sex = patient.Sex
                };

                return report;
            }
            else
            {
                return NotFound($"Patient with id = {patientId} was not found.");
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
    }
}
