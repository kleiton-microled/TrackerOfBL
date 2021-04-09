using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrakingOfBl.Model;
using TrakingOfBl.Model.Context;

namespace TrakingOfBl.Services.Implementations
{
    public class BlTrakingServiceImplementation : IBlTrakingService
    {
        private readonly SqlContext _context;
        public BlTrakingServiceImplementation(SqlContext context)
        {
            _context = context;
        }

        public List<BlTraking> FindAllBls()
        {
            var listBls = _context.blTrakings.ToList();
            return listBls;
        }
    }
}
