namespace RealEstateApp.Services
{
    public interface IEmployeeService
    {
        int CreateEmployee(string firstName, string lastName, string phoneNumber, string emailAddress);
    }
}