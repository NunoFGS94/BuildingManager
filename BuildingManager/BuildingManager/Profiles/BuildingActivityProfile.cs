using AutoMapper;
using BuildingManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuildingManager.Profiles
{
    public class BuildingActivityProfile : Profile
    {
        public BuildingActivityProfile()
        {
            CreateMap<BuildingActivity, BuildingActivityViewModel>().ReverseMap();
        }
    }
}
