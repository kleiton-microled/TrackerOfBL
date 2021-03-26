using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using System.Text.Json.Serialization;
using TrakingOfBl.Model;
using System.Text;

namespace TrakingOfBl.ws
{
    public class LogComexApi : ILogComexApi
    {
        
        public async Task ApiLogComex(string url, string apiKey, string jsonString)
        {
            string tokenResponse = "";
            StringContent content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var baseAddress = new Uri(url);

            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", apiKey);
            var response =  await cliente.PostAsync(baseAddress + "rastreamento/maritimo/novo", content);

            string tokenGerado = await response.Content.ReadAsStringAsync();

            
        }
    }
}
