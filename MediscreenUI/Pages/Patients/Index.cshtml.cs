using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using MediscreenUI.Models;

namespace MediscreenUI.Pages.Patients
{
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
            Console.WriteLine("status after GetAsync is " + response.StatusCode.ToString());

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Patients = JsonConvert.DeserializeObject<List<PatientViewModel>>(content);
            }
        }
    }
}
