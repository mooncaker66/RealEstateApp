using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RealEstateApp.Models;
using RealEstateApp.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISearchServices _searchServices;
        public HomeController(ILogger<HomeController> logger, ISearchServices searchServices)
        {
            _logger = logger;
            _searchServices = searchServices;
        }

        public IActionResult Index(HomeViewModel homeViewModel=null)
        {
            if(homeViewModel==null)
            {
                homeViewModel = new HomeViewModel();
            } 
            if(!string.IsNullOrWhiteSpace(homeViewModel.SearchInput))
            {
                homeViewModel.SearchResults = _searchServices.Search(homeViewModel.SearchInput);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
