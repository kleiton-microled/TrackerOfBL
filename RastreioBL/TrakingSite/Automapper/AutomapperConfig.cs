using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Traking.Business.Models;
using TrakingSite.ViewModels;

namespace TrakingSite.Automapper
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<BL, BlViewModel>().ReverseMap();
        }
    }
}
