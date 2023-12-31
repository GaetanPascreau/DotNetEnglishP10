using MediscreenWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MediscreenWebUI.Pages.Patients
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://patientservice:80"); // this uses the service name defined in docker-compose.yml
        }

        public List<PatientViewModel> Patients { get; set; }

        public async Task OnGetAsync()
        {
                var response = await _httpClient.GetAsync("patients");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Patients = JsonConvert.DeserializeObject<List<PatientViewModel>>(content);
                }         
        }
    }
}