using MediscreenWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using System.Text;

namespace MediscreenWebUI.Pages.Patients
{
    public class EditModel : PageModel
    {
        private readonly HttpClient _httpClient;
        public EditModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://patientservice:80");
        }

        [BindProperty]
        public int PatientId { get; set; }

        [BindProperty]
        public PatientViewModel Patient { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            PatientId = id;

            var response = await _httpClient.GetAsync($"patients/{id}");
            Console.WriteLine("status after GetAsync by Id is " + response.StatusCode.ToString());

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Patient = JsonConvert.DeserializeObject<PatientViewModel>(content);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(PatientViewModel patient)
        {
            PatientId = patient.Id;

            Console.WriteLine("I submitted the form !");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("Model State is invalid !");
                return Page();
            }

            var content = new StringContent(JsonConvert.SerializeObject(patient), Encoding.UTF8, "application/json");
            Console.WriteLine(content.ReadAsStringAsync());
            var response = await _httpClient.PutAsync($"patients/{PatientId}", content);
            Console.WriteLine("status after PutAsync is " + response.StatusCode.ToString());


            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Successfull status code !");
                return RedirectToPage("./Index");
            }
            else
            {
                Console.WriteLine("error !");
                ModelState.AddModelError("", "An error occurred while updating the patient.");
                return Page();
            }
        }
    }
}