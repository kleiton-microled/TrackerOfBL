using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrakingOfBl.Model
{
    public class NewTrakingRegister
    {
        public string ObjFields { get; set; }
        public NewTrakingRegister()
        {

        }

        public NewTrakingRegister(string objFields)
        {
            ObjFields = objFields;
        }
    }
}
