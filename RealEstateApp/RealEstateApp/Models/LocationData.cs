using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Models
{
    public class LocationData
    {
        public string Price { get; set; }
        public string Community { get; set; }
        public string Address { get; set; }

        public double Lng { get; set; }
        public double Lat { get; set; }
    }
}
