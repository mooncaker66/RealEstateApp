using RealEstateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly RealEstateDbContext _realEstateDbContext;
        public EmployeeService(RealEstateDbContext realEstateDbContext)
        {
            _realEstateDbContext = realEstateDbContext;
        }
        public int CreateEmployee(string firstName,
            string lastName, string phoneNumber, string emailAddress)
        {
            Employee newEmployee = new Employee
            {
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber,
                EmailAddress = emailAddress
            };
            _realEstateDbContext.Employees.Add(newEmployee);
            _realEstateDbContext.SaveChanges();
            return newEmployee.EmployeeId;
        }
    }
}
