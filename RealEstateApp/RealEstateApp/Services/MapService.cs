using Newtonsoft.Json;
using RealEstateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace RealEstateApp.Services
{
    public class MapService : IMapService
    {
        public GeoCodeResponse GetGeoCodeByAddress(string street, string city, string state)
        {
            //8650 sw 95th st unit f, 34481, FL
            string address = $"{street}, {city}, {state}";
            address = address.Replace(" ", "+");
            var url = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key=AIzaSyAl2L2Ye4W4DaftxwYg3VrBCHR61trmhUw";
            var httpClient = new HttpClient();
            var response = httpClient.GetAsync(url);
            if (response.Result.IsSuccessStatusCode)
            {
                var json = response.Result.Content.ReadAsStringAsync().Result;
                var geocodeResponse = JsonConvert.DeserializeObject<GeoCodeResponse>(json);
                return geocodeResponse;
            }
            return null;
        }
    }
}
