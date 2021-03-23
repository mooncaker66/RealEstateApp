using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Entities
{
    public class RealEstateDbContext:DbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options):base(options)
        {

        }
        public DbSet<House> Houses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    ID = 1,
                    PropertyType = "condo",
                    Street = "1234 low St",
                    City = "tampa",
                    State = "FL",
                    ZipCode = "33510",
                    YearBuilt = 1996,
                    Beds = 3,
                    Baths = 2,
                    SquareFeet = 3000,
                    HasParking = true,
                    HasBasement = false,
                    HasPool = true
                }
                );
        }
    }
}
