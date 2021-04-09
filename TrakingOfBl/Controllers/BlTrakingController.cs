using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TrakingOfBl.Model;
using TrakingOfBl.Services;
using System.Net.Http;
using TrakingOfBl.ws;
using Newtonsoft.Json;

namespace TrakingOfBl.Controllers
{
    [ApiController]
    [Route("api/bltraking")]
    public class BlTrakingController : ControllerBase
    {
        private readonly ILogger<BlTrakingController> _logger;


        private IBlTrakingService _blTrakingService;
        private ILogComexApi _logComexApi;

        public BlTrakingController(ILogger<BlTrakingController> logger, IBlTrakingService blTrakingService, ILogComexApi logComexApi)
        {
            _logger = logger;
            _blTrakingService = blTrakingService;
            _logComexApi = logComexApi;
        }

        [HttpGet]
        public IActionResult FindAllBls()
        {
            dynamic fields = null;
            string Url = "https://api.logcomex.io/api/v3/";
            string apiKey = "7b86d436a5d89ac4c8be11553b432bad";
            List<BlTraking> list = new List<BlTraking>();
            list = _blTrakingService.FindAllBls();
            if (list == null) return BadRequest("Lista Vazia");

            //for (int i = 0; i < list.Count; i++)
            //{
            //    if (list[i].BlTOken == null)
            //    {
            //        fields = new
            //        {
            //            bl_number = list[i].BlNUmber,
            //            reference = "",
            //            consignee_cnpj = "58138058003100",
            //            emails = "kleiton@microled.com.br",
            //            shipowner = "185"
            //        };

            //        var jsonString = JsonConvert.SerializeObject(fields);
            //        // var trakingRegister = new NewTrakingRegister(jsonString);

            //        var responseRetorno = _logComexApi.ApiLogComex(Url, apiKey, jsonString);
            //    }
            //}

            return Ok(list);
        }
       
    }
}
