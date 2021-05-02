using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Entities
{
    public class Listing
    {
        public int ID { get; set; }
        public int ListingType { get; set; }
        public int HouseId  { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public virtual House House { get; set; }
    }
}
