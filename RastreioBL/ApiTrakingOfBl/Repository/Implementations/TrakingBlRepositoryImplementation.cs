using ApiTrakingOfBl.Model;
using ApiTrakingOfBl.Model.Context;
using ApiTrakingOfBl.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTrakingOfBl.Repository.Implementations
{
    public class TrakingBlRepositoryImplementation : ITrakingBLRepository
    {
        private readonly SqlContext _context;
        public TrakingBlRepositoryImplementation(SqlContext context)
        {
            _context = context;
        }
        public BL CadastroTokenBl(BL bl)
        {
            var result = _context.Bls.SingleOrDefault(b =>b.BlNUmber == bl.BlNUmber);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(bl);
                    _context.SaveChanges();
                }
                catch (Exception)
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
        public BL FindByNumberBL(string numberBl)
        {
            throw new NotImplementedException();
        }
        public List<BL> ListarBls()
        {
            return _context.Bls.ToList();
        }

        public BL TrakingJson(BL bl)
        {
            var result = _context.Bls.SingleOrDefault(b =>b.BlTOken == bl.BlTOken);
            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(bl);
                    _context.SaveChanges();
                }
                catch (Exception)
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
    }
}
