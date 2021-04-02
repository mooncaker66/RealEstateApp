using Microsoft.EntityFrameworkCore;
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


        public List<Listing> Search(int listingType, int propertyType, string address)
        {
            return _realEstateDbContext.Listings
                .Include(l=>l.House).Where(i => i.ListingType == listingType 
                && i.House.PropertyType== propertyType 
                && (i.House.Street.Contains(address) || i.House.City.Contains(address) || i.House.State.Contains(address) || i.House.ZipCode.Contains(address))).ToList();
        }
    }

}
