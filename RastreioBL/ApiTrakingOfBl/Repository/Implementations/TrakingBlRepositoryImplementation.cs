using ApiTrakingOfBl.Model;
using ApiTrakingOfBl.Model.Context;
using ApiTrakingOfBl.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrakingOfBl.Business.Implementations
{
    public class TrakingBlRepositoryImplementation : ITrakingBLRepository
    {
        private readonly SqlContext _context;
        private readonly ILogComexRepository _logComexRepository;
        private readonly ITrakingBLRepository _trakingBLRepository;
        public TrakingBlRepositoryImplementation(SqlContext context, ILogComexRepository logComexRepository, ITrakingBLRepository trakingBLRepository)
        {
            _context = context;
            _logComexRepository = logComexRepository;
            _trakingBLRepository = trakingBLRepository;
        }
        public BL FindByNumberBL(string numberBl)
        {
            throw new NotImplementedException();
        }

        public BL CadastroTokenBl(BL bl)
        {
            var result = _context.Bls.SingleOrDefault(b=>b.BlNUmber == bl.BlNUmber);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(bl);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {

                    throw;
                }
                return result;
            }
            else
            {
                return null;
            }

            
        }

        public List<BL> ListarBls()
        {
            return _context.Bls.ToList();
        }
    }
}
