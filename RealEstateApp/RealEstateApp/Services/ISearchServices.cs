using RealEstateApp.Entities;
using System.Collections.Generic;

namespace RealEstateApp.Services
{
    public interface ISearchServices
    {
        public List<Listing> Search(int? listingType=null, int? propertyType = null, string address = null, string minarea = null, string maxarea = null,
                                    string minprice = null, string maxprice = null, string age = null, int? room = null, int? bed = null, int? bath = null, bool hasair = false,
                                    bool haspool = false, bool hasheating = false, bool haslaundry = false, bool hasgym = false, bool hasparking = false,
                                    bool hasbasement = false);
    }
}