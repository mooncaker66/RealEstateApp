using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateApp.Entities;
using RealEstateApp.Models;
using RealEstateApp.Services;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace RealEstateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchServices _searchServices;
        private readonly IMapService _mapService;
        private readonly IEmployeeService _employeeService;
        private readonly IListingServices _listingServices;

        public HomeController(ILogger<HomeController> logger, ISearchServices searchServices, 
            IMapService mapService, IEmployeeService employeeService, IListingServices listingServices)
        {
            _logger = logger;
            _searchServices = searchServices;
            _mapService = mapService;
            _employeeService = employeeService;
            _listingServices = listingServices;

        }

        public IActionResult Index(HomeViewModel homeViewModel=null)
        {
            if(homeViewModel==null)
            {
                homeViewModel = new HomeViewModel();
            }
            ViewBag.lat = "-34.397";
            ViewBag.lng = "150.644";
            homeViewModel.SearchResults = _searchServices.Search(homeViewModel.ListingType, homeViewModel.HousingType, homeViewModel.Address);
            if (homeViewModel.SearchResults.Any())
            {
                var house = homeViewModel.SearchResults[0];
                var geocodeResponse = _mapService.GetGeoCodeByAddress(house.House.Street, house.House.City, house.House.State);
                ViewBag.lat = geocodeResponse.results[0].geometry.location.lat.ToString();
                ViewBag.lng = geocodeResponse.results[0].geometry.location.lng.ToString();
            }
            return View(homeViewModel);
        }
        [HttpPost]
        public IActionResult Search(HomeViewModel homeViewModel)
        {
            return RedirectToAction("Index", "Home", homeViewModel);
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ShowDetails()
        {
            return View();
        }
        public IActionResult AgentLists()
        {
            return View();
        }
        [Authorize]
        public IActionResult SubmitProperty()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public IActionResult SubmitProperty(Listing listing)
        {
            var userId = HttpContext.User.Claims.Where(i => i.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            listing.UserId = int.Parse(userId.Value);
            _listingServices.AddListing(listing);
            TempData["success"] = "Property Submitted Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult ShowMap()
        {
            var ShowMapModel = new ShowMapViewModel();
            return View(ShowMapModel);
        }
        [HttpPost]
        public IActionResult ShowMap(ShowMapViewModel model)
        {
            ViewBag.lat = "-34.397";
            ViewBag.lng = "150.644";
            var searchResult= _searchServices.Search(model.ListingType, model.HousingType, model.Address);
            if (searchResult.Any())
            {
                var house = searchResult[0];
                var geocodeResponse = _mapService.GetGeoCodeByAddress(house.House.Street, house.House.City, house.House.State);
                ViewBag.lat = geocodeResponse.results[0].geometry.location.lat.ToString();
                ViewBag.lng = geocodeResponse.results[0].geometry.location.lng.ToString();
                ViewBag.SearchResults = searchResult;
                var locations = new List<LocationData>();
                foreach (var listing in searchResult)
                {
                    var location = new LocationData();
                    geocodeResponse = _mapService.GetGeoCodeByAddress(listing.House.Street, listing.House.City, listing.House.State);
                    location.Lat = geocodeResponse.results[0].geometry.location.lat;
                    location.Lng = geocodeResponse.results[0].geometry.location.lng;
                    location.Price = listing.Price.ToString("c2");
                    location.Community = listing.House.Community;
                    location.Address = $"{listing.House.Street}, {listing.House.City}, {listing.House.State}";
                    locations.Add(location);

                }
                ViewBag.locations = locations.ToArray();
            }

            return ShowMap();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public ActionResult SignUp()
        {
            ViewBag.Message = "Employee sign up";
            return View(new Models.EmployeeModel());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(EmployeeModel model)
        {
            if(ModelState.IsValid)
            {
                _employeeService.CreateEmployee(model.FirstName, model.LastName,
                    model.PhoneNumber, model.EmailAddress);
                return RedirectToAction("Index");
            }
            
            return View();
        }



    }
}
