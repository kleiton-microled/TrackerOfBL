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
        private BL _bl;
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

        public object DetalheRastreio(string token)
        {
            string Url = "https://api.logcomex.io/api/v3/";
            string apiKey = "7b86d436a5d89ac4c8be11553b432bad";
            //var nbl = new BL { BlNUmber = "123456", BlTOken = "", Id = 0, PartnerIdCustomer = 0 };

            Task<string> response = _logComexRepository.DetalheRastreio(Url, apiKey, token);
            //dynamic jsonResponse = JsonConvert.DeserializeObject(response);
            var detailResponse = response.Result;
            var json = JsonConvert.DeserializeObject(detailResponse);
            //
            List<BL> bls = ListarBls();
            var bl = bls.Find(x => x.BlTOken == token);
            if (bl.BlTOken != null || bl.BlTOken != "")
            {
                bl.TrakingJson = json.ToString();
                var trakingRegister = _trakingBLRepository.TrakingJson(bl);
            }
            else
            {
                return null;
            }
            return json;
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
                shipowner = EnumShipOwner.COSCO
            };
            var jsonString = JsonConvert.SerializeObject(campos);

            Task<string> response = _logComexRepository.ApiLogComex(Url, apiKey, jsonString);
            //dynamic jsonResponse = JsonConvert.DeserializeObject(response);
            var tokenResponse = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Result);
            foreach (KeyValuePair<string, string> item in tokenResponse)
            {
                if (item.Key == "token")
                {
                    token = item.Value;
                }
            }
            return token;
        }
        public List<BL> ListarBls()
        {
            return _trakingBLRepository.ListarBls(); ;
        }
    }
}
