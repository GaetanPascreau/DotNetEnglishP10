using MediscreenWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MediscreenWebUI.Pages.Reports
{
    public class RiskReportModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public RiskReportModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://riskreportservice:80");
        }
        [BindProperty]
        public int PatientId { get; set; }

        [BindProperty]
        public ReportViewModel Report { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            PatientId = id;
            Console.WriteLine("PatientId = " + PatientId);
            var response = await _httpClient.GetAsync($"Report/{PatientId}");
            Console.WriteLine("response = " + response.StatusCode);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Report = JsonConvert.DeserializeObject<ReportViewModel>(content);
                Console.WriteLine("content = " + content);
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Report = " + Report.PatientName + ", " + Report.Age + ", " + Report.Sex + ", " + Report.RiskLevel);
            }

            Report = new ReportViewModel
            {
                PatientName= Report.PatientName,
                Age= Report.Age,
                Sex= Report.Sex,
                RiskLevel = Report.RiskLevel,
                triggerTermList = Report.triggerTermList
            };
            return Page();
        }
    }
}
