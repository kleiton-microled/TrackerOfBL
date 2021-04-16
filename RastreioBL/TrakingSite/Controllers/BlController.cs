using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traking.Business.Interfaces;
using TrakingSite.ViewModels;

namespace TrakingSite.Controllers
{
    public class BlController : Controller
    {
        private readonly IBlRepository _lblRepository;
        private readonly IMapper _mapper;
        public BlController(IBlRepository blRepository, IMapper mapper)
        {
            _lblRepository = blRepository;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<BlViewModel> ObterRastreioBl(string numeroBl)
        {
            return await _mapper.Map<BlViewModel>(await _lblRepository.ObterDadosBl(numeroBl));
        }
    }
}
