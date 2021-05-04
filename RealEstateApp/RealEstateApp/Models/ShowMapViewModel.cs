using RealEstateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Models
{
    public class ShowMapViewModel
    {
        public string Address { get; set; }
        public int? ListingType { get; set; }

        public int? HousingType { get; set; }
        public string MinArea { get; set; }
        public string  MaxArea { get; set; }
        public string MinPrice  { get; set; }
        public string MaxPrice { get; set; }
        public string Age { get; set; }
        public int? Room { get; set; }
        public int? Bed { get; set; }
        public int? Bath { get; set; }
        public bool HasAir { get; set; }
        public bool HasPool { get; set; }
        public bool HasHeating { get; set; }
        public bool HasLaundry { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasBasement { get; set; }
    }
}
