using ApiTrakingOfBl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrakingOfBl.Business
{
    public interface ILogComexBusiness
    {
        public Task<string> ApiLogComex(string url, string apiKey, string trakingRegister);
        public Task<string> DetalheRastreio(string url, string apiKey, string token);
    }
}
