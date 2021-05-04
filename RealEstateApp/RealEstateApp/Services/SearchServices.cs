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


        public List<Listing> Search(int? listingType, int? propertyType, string address, string minarea, string maxarea,
                                    string minprice, string maxprice , string age , int? room , int? bed , int? bath , bool hasair ,
                                    bool haspool , bool hasheating , bool haslaundry , bool hasgym , bool hasparking ,
                                    bool hasbasement )
        {
            var query = _realEstateDbContext.Listings
                .Include(l => l.House).ThenInclude(h=>h.HouseImages).AsEnumerable();
            if (listingType!=null)
            {
                query = query.Where(i => i.ListingType == listingType.Value);
            }
            if (propertyType != null)
            {
                query = query.Where(i => i.House.PropertyType == propertyType);
            }
            if (!string.IsNullOrWhiteSpace(address))
            {
                query = query.Where(i=>i.House.Street.Contains(address) || i.House.City.Contains(address) || i.House.State.Contains(address) || i.House.ZipCode.Contains(address));
            }
            if(!string.IsNullOrWhiteSpace(minarea))
            {
                int minsqft = int.Parse(minarea);
                query = query.Where(i => i.House.SquareFeet >= minsqft);
            }
            if (!string.IsNullOrWhiteSpace(maxarea))
            {
                int maxsqft = int.Parse(maxarea);
                query = query.Where(i => i.House.SquareFeet <= maxsqft);
            }
            if (hasair)
            {
                query = query.Where(i => i.House.HasAirCondition);
            }
            return query.ToList();
        }
    }

}
