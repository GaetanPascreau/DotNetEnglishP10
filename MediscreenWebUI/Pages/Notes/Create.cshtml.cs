using FluentValidation;
using FluentValidation.Results;
using MediscreenWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace MediscreenWebUI.Pages.Notes
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClientPatient;
        private readonly HttpClient _httpClientNote;
        private readonly IValidator<NoteViewModel> _validator;

        public CreateModel(IHttpClientFactory httpClientFactory, IValidator<NoteViewModel> validator)
        {
            _httpClientPatient = httpClientFactory.CreateClient();
            _httpClientPatient.BaseAddress = new Uri("http://patientservice:80");
            _httpClientNote = httpClientFactory.CreateClient();
            _httpClientNote.BaseAddress = new Uri("http://noteservice:80");
            _validator = validator;
        }

        [BindProperty]
        public NoteViewModel Note { get; set; }

        public PatientViewModel Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var response = await _httpClientPatient.GetAsync($"patients/{id}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Patient = JsonConvert.DeserializeObject<PatientViewModel>(content);
            }

            Note = new NoteViewModel
            {
                PatientId = id,
                DoctorId = 1
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // randomly generate an id for the newly created note, in the 24-digit hexadecimal format
            Note.Id = GenerateRandomHexId(24);

            // Validate the note before saving it
            ValidationResult result = await _validator.ValidateAsync(Note);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return Page();
            }

            var content = new StringContent(JsonConvert.SerializeObject(Note), Encoding.UTF8, "application/json");
            var response = await _httpClientNote.PostAsync($"api/Notes", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("../Patients/Index");
            }
            else
            {
                ModelState.AddModelError("", "An error occurred while creating the note.");
                return Page();
            }
        }

        /// <summary>
        /// Method to generate a random 24 digit hexadecimal string
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GenerateRandomHexId(int length)
        {
            const string chars = "0123456789ABCDEF";
            var random = new Random();
            var hexId = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                hexId.Append(chars[random.Next(chars.Length)]);
            }
            return hexId.ToString();
        }
    }

    public static class Extensions
    {
        public static void AddToModelState(this ValidationResult result, ModelStateDictionary modelState)
        {
            foreach (var error in result.Errors)
            {
                modelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
        }
    }
}