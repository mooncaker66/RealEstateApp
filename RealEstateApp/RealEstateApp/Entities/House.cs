using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Entities
{
    public class House
    {
        public int ID { get; set; }
        public int PropertyType { get; set; }
        public string Community { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Ages { get; set; }
  
        public int Rooms { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public int SquareFeet { get; set; }
        public bool HasAirCondition { get; set; }
        public bool HasHeating { get; set; }
        public bool HasLaudry { get; set; }
        public bool HasGym { get; set; }
        public bool HasParking { get; set; }
        public bool HasBasement { get; set; }
        public bool HasPool { get; set; }
        public virtual List<HouseImage> HouseImages { get; set; }
    }
}
