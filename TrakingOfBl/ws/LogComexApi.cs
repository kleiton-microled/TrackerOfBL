using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using TrakingOfBl.Model;

namespace TrakingOfBl.ws
{
    public class LogComexApi : ILogComexApi
    {
        
        public async Task ApiLogComex(string url, string apiKey, NewTrakingRegister newTrakingRegister)
        {
            string tokenResponse = "";
            var content = new StringContent(newTrakingRegister.ToString(), System.Text.Encoding.Default, "application/json");
            var baseAddress = new Uri(url);
            using (var cliente = new HttpClient { BaseAddress = baseAddress})
            {
                cliente.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", apiKey);
                using (var response = await cliente.PostAsync("rastreamento/maritimo/novo", content))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    tokenResponse = responseData;
                }
            }
        }
    }
}
