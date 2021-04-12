using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrakingOfBl.Repository
{
    public interface ILogComexRepository
    {
        public Task<string> ApiLogComex(string url, string apiKey, string trakingRegister);
    }
}
