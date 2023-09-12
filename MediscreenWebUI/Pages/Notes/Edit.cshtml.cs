using FluentValidation;
using FluentValidation.Results;
using MediscreenWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace MediscreenWebUI.Pages.Notes
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClientPatient;
        private readonly HttpClient _httpClientNote;
        private readonly IValidator<NoteViewModel> _validator;

        public EditModel(IHttpClientFactory httpClientFactory, IValidator<NoteViewModel> validator)
        {
            _httpClientPatient = httpClientFactory.CreateClient();
            _httpClientPatient.BaseAddress = new Uri("http://patientservice:80");
            _httpClientNote = httpClientFactory.CreateClient();
            _httpClientNote.BaseAddress = new Uri("http://noteservice:80");
            _validator = validator;
        }

        [BindProperty]
        public string NoteId { get; set; }

        [BindProperty]
        public NoteViewModel Note { get; set; }

        public PatientViewModel Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            NoteId = id;

            var responseNote = await _httpClientNote.GetAsync($"api/Notes/note/{id}");

            if (responseNote.IsSuccessStatusCode)
            {
                var contentNote = await responseNote.Content.ReadAsStringAsync();
                Note = JsonConvert.DeserializeObject<NoteViewModel>(contentNote);

                var responsePatient = await _httpClientPatient.GetAsync($"patients/{Note.PatientId}");

                if (responsePatient.IsSuccessStatusCode)
                {
                    var contentPatient = await responsePatient.Content.ReadAsStringAsync();
                    Patient = JsonConvert.DeserializeObject<PatientViewModel>(contentPatient);
                    Console.WriteLine($"Patient : {contentPatient}");
                    Console.WriteLine("---------------------------------------------------");
                }
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(NoteViewModel note)
        {
            NoteId = note.Id;

            ValidationResult result = await _validator.ValidateAsync(note);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return Page();
            }

            var contentNote = new StringContent(JsonConvert.SerializeObject(note), Encoding.UTF8, "application/json");
            Console.WriteLine(contentNote.ReadAsStringAsync());
            var responseNote = await _httpClientNote.PutAsync($"api/Notes/{NoteId}", contentNote);

            if (responseNote.IsSuccessStatusCode)
            {
                return RedirectToPage("../Patients/Index");
            }
            else
            {
                Console.WriteLine("error !");
                ModelState.AddModelError("", "An error occurred while updating the note.");
                return Page();
            }
        }
    }
}