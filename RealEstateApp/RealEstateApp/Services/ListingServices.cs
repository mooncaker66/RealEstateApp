﻿using Microsoft.EntityFrameworkCore;
using RealEstateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Services
{
    public class ListingServices : IListingServices
    {
        private readonly RealEstateDbContext _realEstateDbContext;
        public ListingServices(RealEstateDbContext realEstateDbContext)
        {
            _realEstateDbContext = realEstateDbContext;
        }

        public void AddHouseImage(HouseImage houseImage)
        {
            _realEstateDbContext.HouseImages.Add(houseImage);
            _realEstateDbContext.SaveChanges();
        }

        public Listing AddListing(Listing listing)
        {
            _realEstateDbContext.Listings.Add(listing);
            _realEstateDbContext.SaveChanges();
            return listing;
        }

        public Listing GetListingById(int id)
        {
            return _realEstateDbContext.Listings.Include(l => l.House).ThenInclude(h => h.HouseImages).Where(l => l.ID == id).FirstOrDefault();
        }
    }
}
