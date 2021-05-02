using Microsoft.EntityFrameworkCore;
using RealEstateApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Entities
{
    public class RealEstateDbContext:DbContext
    {
        public RealEstateDbContext(DbContextOptions<RealEstateDbContext> options):base(options)
        {

        }
        public DbSet<House> Houses { get; set; }
        public DbSet<Listing> Listings { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    ID = 1,
                    PropertyType = 1,
                    Community = "On Top of The World",
                    Street = "8650 SW 95th Unit F",
                    City = "Ocala",
                    State = "FL",
                    ZipCode = "34481",
                    Ages = "0 - 10 Years",
                    Beds = 3,
                    Baths = 2,
                    SquareFeet = 3000,
                    HasAirCondition = true,
                    HasHeating = true,
                    HasLaudry = true,
                    HasGym = true,
                    HasParking = true,
                    HasBasement = false,
                    HasPool = true
                }
                );
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    ID = 2,
                    PropertyType = 2,
                    Community = "Colonial Hills",
                    Street = "5855 Mockingbird Dr",
                    City = "New Port Richey",
                    State = "FL",
                    ZipCode = "34652",
                    Ages = "0 - 10 Years",
                    Beds = 3,
                    Baths = 2,
                    SquareFeet = 1535,
                    HasAirCondition = true,
                    HasHeating = true,
                    HasLaudry = true,
                    HasGym = false,
                    HasParking = true,
                    HasBasement = false,
                    HasPool = false
                }
                );
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    ID = 3,
                    PropertyType = 1,
                    Community = "Spring Road",
                    Street = "13933 Sound Overlook Dr N",
                    City = "Jacksonville",
                    State = "FL",
                    ZipCode = "32224",
                    Ages = "0 - 10 Years",
                    Beds = 4,
                    Baths = 2,
                    SquareFeet = 2879,
                    HasAirCondition = true,
                    HasHeating = false,
                    HasLaudry = true,
                    HasGym = false,
                    HasParking = true,
                    HasBasement = false,
                    HasPool = false
                }
                );
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    ID = 4,
                    PropertyType = 3,
                    Community = "Spring Road",
                    Street = "759 NE Turtles Turn",
                    City = "Avon Park",
                    State = "FL",
                    ZipCode = "33825",
                    Ages = "0 - 10 Years",
                    Beds = 4,
                    Baths = 2,
                    SquareFeet = 984,
                    HasAirCondition = true,
                    HasHeating = false,
                    HasLaudry = false,
                    HasGym = false,
                    HasParking = false,
                    HasBasement = false,
                    HasPool = false
                }
                );
            modelBuilder.Entity<House>().HasData(
                new House
                {
                    ID = 5,
                    PropertyType = 1,
                    Community = "Spring Road",
                    Street = "3511 Roxboro Rd NE",
                    City = "Atlanta",
                    State = "GA ",
                    ZipCode = "30326",
                    Ages = "0 - 10 Years",
                    Beds = 7,
                    Baths = 9,
                    SquareFeet = 11000,
                    HasAirCondition = true,
                    HasHeating = true,
                    HasLaudry = true,
                    HasGym = true,
                    HasParking = true,
                    HasBasement = true,
                    HasPool = true
                }
                );
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Jake",
                    LastName = "Bull",
                    Password = "dslfjsldfj",
                    EmailAddress = "example@abc.com"

                }
                ) ;
            modelBuilder.Entity<Listing>().HasData(
                new Listing
                {
                    ID = 1,
                    UserId = 1,
                    ListingType = 1,
                    HouseId = 1,    
                    Price = 100000
                });
            modelBuilder.Entity<Listing>().HasData(
                new Listing
                {
                    ID = 2,
                    UserId = 1,
                    ListingType = 2,
                    HouseId = 2,
                    Price = 17000
                });
            modelBuilder.Entity<Listing>().HasData(
                new Listing
                {
                    ID = 3,
                    UserId = 1,
                    ListingType = 1,
                    HouseId = 3,
                    Price = 410000
                });
            modelBuilder.Entity<Listing>().HasData(
                new Listing
                {
                    ID = 4,
                    UserId = 1,
                    ListingType = 1,
                    HouseId = 4,
                    Price = 8900
                });
            modelBuilder.Entity<Listing>().HasData(
                new Listing
                {

                    ID = 5,
                    UserId = 1,
                    ListingType = 1,
                    HouseId = 5,
                    Price = 3300000
                });
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 100000,
                    FirstName = "Zhixuu",
                    LastName = "Zhao",
                    PhoneNumber = "123456789",
                    EmailAddress = "zhixun@usf.edu"                  
                }
                ); 
        }
    }
}
