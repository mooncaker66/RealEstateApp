using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RealEstateApp.Entities;
using RealEstateApp.Models;

namespace RealEstateApp.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Listing, SubmitPropertyViewModel>();
            CreateMap<Listing, ListingViewModel>();

        }

    }
}
