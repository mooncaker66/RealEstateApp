using Microsoft.AspNetCore.Http;
using RealEstateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Models
{
    public class SubmitPropertyViewModel: Listing
    {
        public List<IFormFile> UploadFiles { get; set; }
    }
}
