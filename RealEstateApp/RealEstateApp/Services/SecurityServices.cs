using RealEstateApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RealEstateApp.Services
{
    public class SecurityServices : ISecurityServices
    {
        private readonly RealEstateDbContext _realEstateDbContext;
        public SecurityServices(RealEstateDbContext realEstateDbContext)
        {
            _realEstateDbContext = realEstateDbContext;
        }
        public void Register(User user)
        {
            user.Password = EnryptString(user.Password);
            _realEstateDbContext.Users.Add(user);
            _realEstateDbContext.SaveChanges();
        }
        public string DecryptString(string encrString)
        {
            byte[] b;
            string decrypted;
            try
            {
                b = Convert.FromBase64String(encrString);
                decrypted = System.Text.ASCIIEncoding.ASCII.GetString(b);
            }
            catch (FormatException fe)
            {
                decrypted = "";
            }
            return decrypted;
        }

        public string EnryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encrypted = Convert.ToBase64String(b);
            return encrypted;
        }

        public User ValidateUser(string emailAddress, string password)
        {
            password = EnryptString(password);
            return _realEstateDbContext.Users.Where(i => i.EmailAddress == emailAddress && i.Password == password).FirstOrDefault();

        }
    }
}
