using RealEstateApp.Models;

namespace RealEstateApp.Services
{
    public interface IMapService
    {
        GeoCodeResponse GetGeoCodeByAddress(string street, string city, string state);
    }
}