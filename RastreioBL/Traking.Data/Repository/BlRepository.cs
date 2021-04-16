using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Traking.Business.Interfaces;
using Traking.Business.Models;

namespace Traking.Data.Repository
{
    public class BlRepository : Repository<BL>, IBlRepository
    {
        public async Task<BL> ObterDadosBl(string numeroBl)
        {
            return await _context.Bls.AsNoTracking().FirstOrDefaultAsync(b =>b.NumeroBl == numeroBl);
        }
    }
}
