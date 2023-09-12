using MediscreenWebUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MediscreenWebUI.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://noteservice:80"); // This uses the service name defined in docker-compose.yml
        }

        public List<NoteViewModel> Notes { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync("api/notes");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Notes = JsonConvert.DeserializeObject<List<NoteViewModel>>(content);
                Console.WriteLine(content);
                Console.WriteLine("---------------------------------------------------");
            }
        }
    }
}