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
using AutoMapper;
using System.IO;
using System;

namespace RealEstateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchServices _searchServices;
        private readonly IMapService _mapService;
        private readonly IEmployeeService _employeeService;
        private readonly IListingServices _listingServices;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ISearchServices searchServices, 
            IMapService mapService, IEmployeeService employeeService, IListingServices listingServices, IMapper mapper)
        {
            _logger = logger;
            _searchServices = searchServices;
            _mapService = mapService;
            _employeeService = employeeService;
            _listingServices = listingServices;
            _mapper = mapper;

        }

        public IActionResult Index(HomeViewModel homeViewModel=null)
        {
            if(homeViewModel==null)
            {
                homeViewModel = new HomeViewModel();
            }
            ViewBag.lat = "-34.397";
            ViewBag.lng = "150.644";
            var searchResult = _searchServices.Search(homeViewModel.ListingType, homeViewModel.HousingType, homeViewModel.Address);
            if (searchResult.Any())
            {
                homeViewModel.ListingViewModels = _mapper.Map<List<ListingViewModel>>(searchResult);

                var house = homeViewModel.ListingViewModels[0];
                var geocodeResponse = _mapService.GetGeoCodeByAddress(house.House.Street, house.House.City, house.House.State);
                ViewBag.lat = geocodeResponse.results[0].geometry.location.lat.ToString();
                ViewBag.lng = geocodeResponse.results[0].geometry.location.lng.ToString();
                foreach (var listing in homeViewModel.ListingViewModels)
                {
                    listing.ImageSrcs = new List<string>();
                    if (listing.House.HouseImages != null)
                    {
                        foreach (var item in listing.House.HouseImages)
                        {
                            var base64 = Convert.ToBase64String(item.Image);
                            var ImageSrc = $"data:image/jpeg; base64, {base64}";
                            listing.ImageSrcs.Add(ImageSrc);
                        }

                    }
                }               
            }
            homeViewModel.ListingViewModels = homeViewModel.ListingViewModels.OrderByDescending(l => l.ID).ToList();
            return View(homeViewModel);
        }
        [HttpPost]
        public IActionResult Search(HomeViewModel homeViewModel)
        {
            return RedirectToAction("ShowMap", "Home", new { listingType = homeViewModel.ListingType, housingType = homeViewModel.HousingType, address = homeViewModel.Address } );
        }
        public IActionResult ShowDetails(int id)
        {
            Listing listing = _listingServices.GetListingById(id);
            var listingViewModel = _mapper.Map<ListingViewModel>(listing);
            listingViewModel.ImageSrcs = new List<string>();

            if (listing.House.HouseImages != null)
            {
                foreach (var item in listing.House.HouseImages)
                {
                    var base64 = Convert.ToBase64String(item.Image);
                    var ImageSrc = $"data:image/jpeg; base64, {base64}";
                    listingViewModel.ImageSrcs.Add(ImageSrc);
                }

            }
            return View(listingViewModel);
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
        public IActionResult SubmitProperty(SubmitPropertyViewModel submitPropertyViewModel)
        {
            var userId = HttpContext.User.Claims.Where(i => i.Type == ClaimTypes.NameIdentifier).FirstOrDefault();

            submitPropertyViewModel.UserId = int.Parse(userId.Value);
           var listing = _listingServices.AddListing(submitPropertyViewModel);
            foreach (var item in submitPropertyViewModel.UploadFiles)
            {
                var memoryStream = new MemoryStream();
                item.CopyTo(memoryStream);
                var houseImage = new HouseImage
                {
                    HouseID = listing.House.ID,
                    Image = memoryStream.ToArray(),
                };
                _listingServices.AddHouseImage(houseImage);
            }
            TempData["success"] = "Property Submitted Successfully";
            return RedirectToAction("Index");
        }

        public IActionResult ShowMap(int listingType=0, int housingType=0, string address ="", string minarea="",string maxarea="",
                                    string minprice="",string maxprice="",string age="", int room=0,int bed=0, int bath=0, bool hasair=false,
                                    bool haspool=false,bool hasheating=false,bool haslaundry = false, bool hasgym = false, bool hasparking=false,
                                    bool hasbasement=false)
        {
            var model = new ShowMapViewModel()
            {
                ListingType=listingType,
                HousingType=housingType,
                Address=address,
                MinArea = minarea,
                MaxArea = maxarea,
                MinPrice = minprice,
                MaxPrice = maxprice,
                Age = age,
                Room = room,
                Bed = bed,
                Bath = bath,
                HasAir = hasair,
                HasPool = haspool,
                HasHeating = hasheating,
                HasLaundry = haslaundry,
                HasGym = hasgym,
                HasParking = hasparking,
                HasBasement = hasbasement
            };
            ViewBag.lat = "-34.397";
            ViewBag.lng = "150.644";

            var searchResult = _searchServices.Search(model.ListingType, model.HousingType, model.Address, model.MinArea, model.MaxArea,model.MinPrice,
                model.MaxPrice,model.Age,model.Room,model.Bed,model.Bath,model.HasAir,model.HasPool,model.HasHeating,model.HasLaundry,model.HasGym,
                model.HasParking,model.HasBasement);

            if (searchResult.Any())
            {
                var listingViewModels = _mapper.Map<List<ListingViewModel>>(searchResult);
                var house = listingViewModels[0];
                var geocodeResponse = _mapService.GetGeoCodeByAddress(house.House.Street, house.House.City, house.House.State);
                ViewBag.lat = geocodeResponse.results[0].geometry.location.lat.ToString();
                ViewBag.lng = geocodeResponse.results[0].geometry.location.lng.ToString();
                var locations = new List<LocationData>();
                foreach (var listing in listingViewModels)
                {
                    var location = new LocationData();
                    geocodeResponse = _mapService.GetGeoCodeByAddress(listing.House.Street, listing.House.City, listing.House.State);
                    location.Lat = geocodeResponse.results[0].geometry.location.lat;
                    location.Lng = geocodeResponse.results[0].geometry.location.lng;
                    location.Price = listing.Price.ToString("c2");
                    location.Community = listing.House.Community;
                    location.Address = $"{listing.House.Street}, {listing.House.City}, {listing.House.State}";
                    locations.Add(location);
                    listing.ImageSrcs = new List<string>();
                    if (listing.House.HouseImages != null)
                    {
                        foreach (var item in listing.House.HouseImages)
                        {
                            var base64 = Convert.ToBase64String(item.Image);
                            var ImageSrc = $"data:image/jpeg; base64, {base64}";
                            listing.ImageSrcs.Add(ImageSrc);
                        }

                    }

                }
                ViewBag.listingViewModels = listingViewModels;

                ViewBag.locations = locations.ToArray();
            }
            return View(model);
        }
        [HttpPost]
        public IActionResult ShowMap(ShowMapViewModel model)
        {
            return ShowMap(model.ListingType, model.HousingType, model.Address, model.MinArea, model.MaxArea, model.MinPrice,
                model.MaxPrice, model.Age, model.Room, model.Bed, model.Bath, model.HasAir, model.HasPool, model.HasHeating, model.HasLaundry, model.HasGym,
                model.HasParking, model.HasBasement);
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
