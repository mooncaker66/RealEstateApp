﻿using RealEstateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Models
{
    public class ListingViewModel: Listing
    {
        public List<string> ImageSrcs { get; set; }
    }
}
