using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrakingOfBl.Model;

namespace TrakingOfBl.Services
{
    public interface IBlTrakingService
    {
        List<BlTraking> FindAllBls();
    }
}
