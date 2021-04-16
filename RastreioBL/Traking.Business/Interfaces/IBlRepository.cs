using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Traking.Business.Models;

namespace Traking.Business.Interfaces
{
    public interface IBlRepository : IRepository<BL>
    {
        Task<BL> ObterDadosBl(string numeroBl);
    }
}
