using ApiTrakingOfBl.Business.ObjectValues;
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
    public class TrakingBlBusinessImplementation : ITrakingBLBusiness
    {
        private readonly SqlContext _context;
        private readonly ILogComexRepository _logComexRepository;
        private readonly ITrakingBLRepository _trakingBLRepository;
        public TrakingBlBusinessImplementation(SqlContext context, ILogComexRepository logComexRepository, ITrakingBLRepository trakingBLRepository)
        {
            _context = context;
            _logComexRepository = logComexRepository;
            _trakingBLRepository = trakingBLRepository;
        }

        public BL CadastrarTokenBl(BL bl)
        {
            var response = _trakingBLRepository.CadastroTokenBl(bl);
            return response;
        }

        public BL FindByNumberBL(string numberBl)
        {
            throw new NotImplementedException();
        }

        public string IniciarRastreioLogComex(BL bl)
        {
            var token = "";
            string Url = "https://api.logcomex.io/api/v3/";
            string apiKey = "7b86d436a5d89ac4c8be11553b432bad";
            //var nbl = new BL { BlNUmber = "123456", BlTOken = "", Id = 0, PartnerIdCustomer = 0 };
            dynamic campos = null;
            campos = new
            {
                bl_number = bl.BlNUmber,
                reference = "",
                consignee_cnpj = "58138058003100",
                emails = "kleiton@microled.com.br",
                shipowner = EnumShipOwner.HAMBURGSUD
            };
            var jsonString = JsonConvert.SerializeObject(campos);

            Task<string> response = _logComexRepository.ApiLogComex(Url, apiKey, jsonString);
            //dynamic jsonResponse = JsonConvert.DeserializeObject(response);

            if (response.Result.Contains("{\"token\":\""))
            {
                token = response.Result;
            }

            return token;

        }
        public List<BL> ListarBls()
        {
            return _context.Bls.ToList();
        }
    }
}
