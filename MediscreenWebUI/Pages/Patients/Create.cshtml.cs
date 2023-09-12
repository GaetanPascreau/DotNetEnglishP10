using FluentValidation;
using FluentValidation.Results;
using MediscreenWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace MediscreenWebUI.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        private readonly IValidator<PatientViewModel> _validator;

        public CreateModel(IHttpClientFactory httpClientFactory, IValidator<PatientViewModel> validator)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://patientservice:80");
            _validator = validator;
        }

        [BindProperty]
        public PatientViewModel Patient { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(PatientViewModel patient)
        {
            Patient = patient;

            ValidationResult result = await _validator.ValidateAsync(patient);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return Page();
            }

            var content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"patients", content);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                Console.WriteLine("error !");
                ModelState.AddModelError("", "An error occurred while creating the patient.");
                return Page();
            }
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