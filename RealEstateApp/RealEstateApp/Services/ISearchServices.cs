using RealEstateApp.Entities;
using System.Collections.Generic;

namespace RealEstateApp.Services
{
    public interface ISearchServices
    {
        List<Listing> Search(int listingType, int propertyType, string address, string minArea="");
    }
}