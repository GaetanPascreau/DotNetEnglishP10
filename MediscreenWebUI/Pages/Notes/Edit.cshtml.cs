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
        private readonly HttpClient _httpClient1;
        private readonly HttpClient _httpClient2;
        private readonly IValidator<NoteViewModel> _validator;

        public EditModel(IHttpClientFactory httpClientFactory, IValidator<NoteViewModel> validator)
        {
            _httpClient1 = httpClientFactory.CreateClient();
            _httpClient1.BaseAddress = new Uri("http://patientservice:80");
            _httpClient2 = httpClientFactory.CreateClient();
            _httpClient2.BaseAddress = new Uri("http://noteservice:80");
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

            var response = await _httpClient2.GetAsync($"api/Notes/note/{id}");
            Console.WriteLine("status after GetAsync by Id is " + response.StatusCode.ToString());

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Note = JsonConvert.DeserializeObject<NoteViewModel>(content);

                var response2 = await _httpClient1.GetAsync($"patients/{Note.PatientId}");
                Console.WriteLine("Status after Patient GetAsync is " + response2.StatusCode.ToString());
                if (response2.IsSuccessStatusCode)
                {
                    Console.WriteLine("entered the Patient if statement.");
                    var content1 = await response2.Content.ReadAsStringAsync();
                    Patient = JsonConvert.DeserializeObject<PatientViewModel>(content1);
                    Console.WriteLine(content1);
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine(Patient);
                }
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(NoteViewModel note)
        {
            NoteId = note.Id;

            Console.WriteLine("I submitted the form !");
            ValidationResult result = await _validator.ValidateAsync(note);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                Console.WriteLine("Model State is invalid !");
                return Page();
            }

            var content2 = new StringContent(JsonConvert.SerializeObject(note), Encoding.UTF8, "application/json");
            Console.WriteLine(content2.ReadAsStringAsync());
            var response3 = await _httpClient2.PutAsync($"api/Notes/{NoteId}", content2);
            Console.WriteLine("status after PutAsync is " + response3.StatusCode.ToString());


            if (response3.IsSuccessStatusCode)
            {
                Console.WriteLine("Successfull status code !");
                // return RedirectToPage("./PatientNotes/");
                // return RedirectToPage(Request.Headers["Referer"].ToString());
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