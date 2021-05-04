using RealEstateApp.Entities;
using System.Collections.Generic;

namespace RealEstateApp.Services
{
    public interface ISearchServices
    {
        List<Listing> Search(int listingType, int propertyType, string address, string minArea="", string maxArea = null, string minPrice = null, string maxPrice = null, string age = null, int room = 0, int bed = 0, int bath = 0, bool hasAir = false, bool hasPool = false, bool hasHeating = false, bool hasLaundry = false, bool hasGym = false, bool hasParking = false, bool hasBasement = false);
    }
}