using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrakingOfBl.Model;

namespace TrakingOfBl.ws
{
    public interface ILogComexApi
    {
        public Task ApiLogComex(string url, string apiKey, NewTrakingRegister trakingRegister);
    }
}
