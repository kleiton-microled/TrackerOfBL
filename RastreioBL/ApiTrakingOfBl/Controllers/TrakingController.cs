using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTrakingOfBl.Model;
using ApiTrakingOfBl.Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiTrakingOfBl.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class TrakingController : ControllerBase
    {
        private readonly ILogger<TrakingController> _logger;
        private ITrakingBLBusiness _bLBusiness;
        private readonly ILogComexBusiness _logComexBusiness;
       

        public TrakingController(ILogger<TrakingController> logger, ITrakingBLBusiness bLBusiness, ILogComexBusiness logComexBusiness)
        {
            _logger = logger;
            _bLBusiness = bLBusiness;
            _logComexBusiness = logComexBusiness;
        }
        [HttpGet]
        [Route("listar")]
        public IActionResult ListarBls()
        {
            List<BL> listBls = new List<BL>();
            listBls = _bLBusiness.ListarBls();


            return Ok(listBls);
        }
        [HttpPost]
        [Route("rastrear/iniciar")]
        public IActionResult IniciarRastreioBL([FromBody] BL bl)
        {
            var listaDeBls =  _bLBusiness.ListarBls();
            foreach (var item in listaDeBls)
            {
                if (item.BlTOken == null || item.BlTOken == "")
                {
                   bl = new BL { BlNUmber = item.BlNUmber, Id = item.Id, BlTOken = item.BlTOken, PartnerIdCustomer = item.PartnerIdCustomer};
                    var token = _bLBusiness.IniciarRastreioLogComex(bl);
                    if (token != "")
                    {
                        bl.BlTOken = token;
                       CadastrarTokenBl(bl);
                        DetalheRastreio(token);
                    } 
                }
            }
            return Ok();
        }
        [HttpPut]
        [Route("cadastrar/token")]
        public IActionResult CadastrarTokenBl([FromBody] BL bl)
        {
            if (bl == null) return BadRequest("Requisicao invalida");
            return Ok(_bLBusiness.CadastrarTokenBl(bl));
        }
        [HttpGet]
        [Route("rastrear/detalhe")]
        public IActionResult DetalheRastreio(string token)
        {
            if (token == null) return BadRequest("requisicao invalida");
            var response = _bLBusiness.DetalheRastreio(token);
            return Ok("Rastreamento Gravado!");
        }

        
    }
}
