using RealEstateApp.Entities;

namespace RealEstateApp.Services
{
    public interface IListingServices
    {
        Listing AddListing(Listing listing);
        void AddHouseImage(HouseImage houseImage);
    }
}