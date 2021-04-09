﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiTrakingOfBl.Business.Implementations
{
    public class LogComexBusinessImplementation : ILogComexBusiness
    {
        public async Task<string> ApiLogComex(string url, string apiKey, string trakingRegister)
        {
            string tokenResponse = "";
            
            StringContent content = new StringContent(trakingRegister, Encoding.UTF8, "application/json");
            var baseAddress = new Uri(url);

            HttpClient cliente = new HttpClient();
            cliente.DefaultRequestHeaders.TryAddWithoutValidation("x-api-key", apiKey);
            var response = await cliente.PostAsync(baseAddress + "rastreamento/maritimo/novo", content);

            string tokenGerado = await response.Content.ReadAsStringAsync();

            return tokenGerado;
        }
    }
}