using RealEstateApp.Entities;

namespace RealEstateApp.Services
{
    public interface ISecurityServices
    {
        string DecryptString(string encrString);
        string EnryptString(string strEncrypted);
        public void Register(User user);
        User ValidateUser(string emailAddress, string password);
    }
}