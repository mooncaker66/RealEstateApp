using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Models
{
    public class EmployeeModel
    {    
     

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="Please type your first name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Please type your last name")]
        public string LastName { get; set; }

        [DataType(DataType.PhoneNumber,ErrorMessage ="you need to enter the correct phone number")]
        public  string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Please type your Email Address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        [Compare("EmailAddress", ErrorMessage ="The Email has to match")]
        public string ConfirmEmail { get; set; }

        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength =6, ErrorMessage ="You need to provide a long enough password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="you password has to match.")]
        public string ConfirmPassword { get; set; }
    }
}
