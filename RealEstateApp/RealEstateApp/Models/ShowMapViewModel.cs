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
        public string MinArea { get; set; }
        public List<ListingViewModel> SearchResults { get; set; }
        public ShowMapViewModel()
        {
            SearchResults = new List<ListingViewModel>();
            Address = "";
        }
    }
}
