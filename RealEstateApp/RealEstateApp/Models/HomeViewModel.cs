using RealEstateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Models
{
    public class HomeViewModel
    {
        public int? ListingType { get; set; }
        public string Address { get; set; }

        public int? HousingType { get; set; }

        public List<ListingViewModel> ListingViewModels { get; set; }
        public HomeViewModel()
        {
            ListingViewModels = new List<ListingViewModel>();
        }
    }
}
