using RealEstateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Services
{
    public class SearchServices : ISearchServices
    {
        private readonly RealEstateDbContext _realEstateDbContext;
        public SearchServices(RealEstateDbContext realEstateDbContext)
        {
            _realEstateDbContext = realEstateDbContext;
        }


        public List<House> Search(string searchInput)
        {
            return _realEstateDbContext.Houses.Where(i => i.ZipCode == searchInput).ToList();
        }

    }

}
