using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Entities
{
    public class House
    {
        public int ID { get; set; }
        public string PropertyType { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public int YearBuilt { get; set; }
        public int Beds { get; set; }
        public int Baths { get; set; }
        public int SquareFeet { get; set; }
        public bool HasParking { get; set; }
        public bool HasBasement { get; set; }
        public bool HasPool { get; set; }
       
    }
}
