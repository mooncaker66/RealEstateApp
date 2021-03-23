using RealEstateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Models
{
    public class HomeViewModel
    {
        public string SearchInput { get; set; }
        public List<House> SearchResults { get; set; }
        public HomeViewModel()
        {
            SearchResults = new List<House>();

        }
    }
}
