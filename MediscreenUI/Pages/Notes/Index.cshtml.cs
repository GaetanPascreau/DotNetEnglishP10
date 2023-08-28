using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MediscreenUI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace MediscreenUI.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient();
            _httpClient.BaseAddress = new Uri("http://noteservice:80"); // this uses the service name defined in docker-compose.yml
        }

        public List<NoteViewModel> Notes { get; set; }

        public async Task OnGetAsync()
        {
            var response = await _httpClient.GetAsync("api/notes");
            Console.WriteLine("Status after GetAsync is " + response.StatusCode.ToString());

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("entered the if statement.");
                var content = await response.Content.ReadAsStringAsync();
                Notes = JsonConvert.DeserializeObject<List<NoteViewModel>>(content);
                Console.WriteLine(content);
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine(Notes);
            }
        }
    }
}
