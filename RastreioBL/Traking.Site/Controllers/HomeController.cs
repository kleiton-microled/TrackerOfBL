using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Traking.Site.Data;
using Traking.Site.Models;

namespace Traking.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SqlContext _context;

        public HomeController(ILogger<HomeController> logger, SqlContext context)
        {
            _logger = logger;
            _context = context;
        }
        [HttpGet]
        [Route("/{numero}")]
        public IActionResult Index(string numero)
        {
            var trakingDbContext = _context.Bls.FirstOrDefault(b=>b.BlNumber == numero);

            dynamic consignee = JsonConvert.DeserializeObject<dynamic>(trakingDbContext.JsonRastreio);
            Consignee consig = new Consignee 
            { 
                name = consignee.consignee.name
            };
            //Consignee consignee = JsonConvert.DeserializeObject<Consignee>(json);
            return View(trakingDbContext);
        }

        public IActionResult Traking()
        {
            return PartialView("_transporte_logistica");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
