using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Traking.Site.Models
{
    public class Consignee
    {
        public string name { get; set; }
        public string code { get; set; }
        public string region { get; set; }
        public string city { get; set; }
        public string address { get; set; }
        public string address_complement { get; set; }
        public string zip_code { get; set; }
        public string number { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string activity { get; set; }
        public string legal_nature { get; set; }
        public string type { get; set; }
        public string type_title { get; set; }
    }
    public class Rootobject
    {
        public Consignee[] Consignees { get; set; }
    }
}
