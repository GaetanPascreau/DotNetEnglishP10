using MediscreenWebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MediscreenWebUI.Pages.Notes
{
    public class PatientNotesModel : PageModel
    {
        private readonly HttpClient _httpClientNote;
        private readonly HttpClient _httpClientPatient;


        public PatientNotesModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientNote = httpClientFactory.CreateClient();
            _httpClientNote.BaseAddress = new Uri("http://noteservice:80"); // This uses the service name defined in docker-compose.yml
            _httpClientPatient = httpClientFactory.CreateClient();
            _httpClientPatient.BaseAddress = new Uri("http://patientservice:80");
        }

        public PatientViewModel Patient { get; set; }

        public List<NoteViewModel> Notes { get; set; }

        public async Task OnGetAsync(int id)
        {

            var responsePatient = await _httpClientPatient.GetAsync($"patients/{id}");

            if (responsePatient.IsSuccessStatusCode)
            {
                var contentPatient = await responsePatient.Content.ReadAsStringAsync();
                Patient = JsonConvert.DeserializeObject<PatientViewModel>(contentPatient);
                Console.WriteLine(contentPatient);
                Console.WriteLine("---------------------------------------------------");
            }

            var responseNote = await _httpClientNote.GetAsync($"api/notes/patient/{id}/notes");

            if (responseNote.IsSuccessStatusCode)
            {
                Console.WriteLine("entered the Notes if statement.");
                var contentNote = await responseNote.Content.ReadAsStringAsync();
                Notes = JsonConvert.DeserializeObject<List<NoteViewModel>>(contentNote);
                Console.WriteLine(contentNote);
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}