using MediscreenUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace MediscreenUI.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public CreateModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://patientservice:80");
        }


        [BindProperty]
        public PatientViewModel Patient { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(PatientViewModel patient)
        {
            Console.WriteLine("I submitted the form !");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model State is invalid !");
                return Page();
            }

            var content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
            Console.WriteLine(content.ReadAsStringAsync());
            var response = await _httpClient.PostAsync($"patients", content);
            Console.WriteLine("status after PostAsync is " + response.StatusCode.ToString());

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Successfull status code !");
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
}

