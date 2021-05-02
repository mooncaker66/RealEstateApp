using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Entities;
using RealEstateApp.Models;
using RealEstateApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace RealEstateApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISecurityServices _securityServices;
        public AccountController(ISecurityServices securityServices)
        {
            _securityServices = securityServices;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if(registerViewModel.Password != registerViewModel.ConfirmPassword)
            {
                ViewBag.error = "Password must match!";
                return Register();
            }
            _securityServices.Register(registerViewModel);
            return RedirectToAction("Login");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            User user = _securityServices.ValidateUser(loginModel.EmailAddress, loginModel.Password);
            if(user==null)
            {
                ViewBag.error = "Invalid Email or Password!";
                return Login();

            }
            var claims = new List<Claim> //think of it a permission
                {
                    new Claim(ClaimTypes.GivenName, user.FirstName),
                    new Claim(ClaimTypes.Surname, user.LastName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.EmailAddress),
  
                };
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

            return RedirectToAction("Index","Home");
        }
    }
}
