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
        public int ListingType { get; set; }

        public int HousingType { get; set; }
        public List<Listing> SearchResults { get; set; }
        public ShowMapViewModel()
        {
            SearchResults = new List<Listing>();
        }
    }
}
