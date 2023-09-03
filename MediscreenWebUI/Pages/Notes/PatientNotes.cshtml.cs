using MediscreenWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MediscreenWebUI.Pages.Notes
{
    public class PatientNotesModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly HttpClient _httpClient2;


        public PatientNotesModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://noteservice:80"); // this uses the service name defined in docker-compose.yml
            _httpClient2 = httpClientFactory.CreateClient();
            _httpClient2.BaseAddress = new Uri("http://patientservice:80");
        }

        [BindProperty]
        public int PatientId { get; set; }

        public PatientViewModel Patient { get; set; }

        public List<NoteViewModel> Notes { get; set; }

        public async Task OnGetAsync(int id)
        {
            PatientId = id;

            var response1 = await _httpClient2.GetAsync($"patients/{id}");
            Console.WriteLine("Status after Patient GetAsync is " + response1.StatusCode.ToString());
            if (response1.IsSuccessStatusCode)
            {
                Console.WriteLine("entered the Patient if statement.");
                var content1 = await response1.Content.ReadAsStringAsync();
                Patient = JsonConvert.DeserializeObject<PatientViewModel>(content1);
                Console.WriteLine(content1);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(Patient);
            }

            var response2 = await _httpClient.GetAsync($"api/notes/patient/{id}/notes");
            Console.WriteLine("Status after Notes GetAsync is " + response2.StatusCode.ToString());

            if (response2.IsSuccessStatusCode)
            {
                Console.WriteLine("entered the Notes if statement.");
                var content2 = await response2.Content.ReadAsStringAsync();
                Notes = JsonConvert.DeserializeObject<List<NoteViewModel>>(content2);
                Console.WriteLine(content2);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(Notes);
            }
        }
    }
}