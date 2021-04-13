using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrakingOfBl.Model
{
    public class DetailBl
    {
        public string Token { get; set; }
        public string Consignee { get; set; }
        public DetailBl()
        {

        }
        public DetailBl(string token, string consignee)
        {
            Token = token;
            Consignee = consignee;
        }
    }
}
