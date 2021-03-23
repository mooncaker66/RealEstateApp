using RealEstateApp.Entities;
using System.Collections.Generic;

namespace RealEstateApp.Services
{
    public interface ISearchServices
    {
        List<House> Search(string searchInput);
    }
}