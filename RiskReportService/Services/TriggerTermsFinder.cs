using Newtonsoft.Json;
using RiskReportService.Contracts;
using RiskReportService.Data;
using RiskReportService.Models;
using System.Text.RegularExpressions;

namespace RiskReportService.Services
{
    public class TriggerTermsFinder : ITriggerTermsFinder
    {
        private readonly HttpClient _httpClientNote;
        private readonly TriggerTerms _triggerTerms;

        public TriggerTermsFinder(IHttpClientFactory httpClientFactory, TriggerTerms triggerTerms)
        {
            _httpClientNote = httpClientFactory.CreateClient();
            _httpClientNote.BaseAddress = new Uri("http://noteservice:80");
            _triggerTerms = triggerTerms;
        }

        public async Task<TriggerTermList> CountTriggerTerms(int patientId)
        {
            try
            {
                // Get the list of trigger terms to look for in patients' notes
                var triggers = _triggerTerms.triggerTerms;
                
                // Get the notes for the given patient
                var response = await _httpClientNote.GetAsync($"api/Notes/patient/{patientId}/notes");
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine("Content = " + content);

                var notes = JsonConvert.DeserializeObject<List<NoteViewModel>>(content);

                if (notes == null)
                {
                    return null;
                }

                // Create a dictionnary to store the ocurences
                Dictionary<string, int> occurences = new Dictionary<string, int>();
                List<string> triggersDetected = new List<string>();

                foreach (string trigger in triggers)
                {
                    bool triggerFound = false;

                    foreach (var note in notes)
                    {
                        // We look for single-word and multi-words trigger terms isolated by spaces
                        if (Regex.IsMatch(note.NoteContent, $@"\b{Regex.Escape(trigger)}\b", RegexOptions.IgnoreCase))
                        {
                            triggerFound = true;
                            triggersDetected.Add(trigger);
                            break; // Exit the inner loop as soon as the trigger is found (= if found,a trigger term is counted only once, for a given patient)
                        }
                    }

                    int count = triggerFound ? 1 : 0; // Count 1 if the trigger was found, otherwise count 0

                    occurences[trigger] = count;
                    Console.WriteLine($"trigger = {trigger} : count = {count}");
                }

                // Calculate the total count of occurences
                int totalCount = occurences.Values.Sum();
                Console.WriteLine("Number of trigger terms found  = " + totalCount);

                if (totalCount == 0)
                {
                    triggersDetected = new List<string> { "none" };
                }

                var result = new TriggerTermList
                {
                    TriggerTerms = triggersDetected,
                    TriggersCount = totalCount
                };

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred : " + ex.Message);
                return null;
            }
        }
    }
}
