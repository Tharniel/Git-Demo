using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Riddler.ViewModels
{
    internal class RiddlePageViewModel
    {
        public List<Models.Riddle> TheRiddles { get; set; }

        public RiddlePageViewModel()
        {
            var task = Task.Run(() => GetRiddleAsync());
            task.Wait();
            TheRiddles = task.Result;
        }

        public static async Task<List<Models.Riddle>> GetRiddleAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://api.api-ninjas.com/");
            client.DefaultRequestHeaders.Add("X-Api-Key", "0SdiJM+HXPbdpg973bh43w==ZTSJKQf13WtqqxiM");
            List<Models.Riddle> riddles = new List<Models.Riddle>();
    
            HttpResponseMessage response = await client.GetAsync("v1/riddles?limit=3");
            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var riddlesArray = JsonSerializer.Deserialize<Models.Riddle[]>(responseString);
                if (riddlesArray != null && riddlesArray.Length > 0)
                {
                    riddles.AddRange(riddlesArray);
                }
            }
            return riddles;
        }
    }
}