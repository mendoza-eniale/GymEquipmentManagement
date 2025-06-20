using GEMCommon; // Ensure to include the correct namespace
using GEMDataAccess;
namespace GEMBusinessLogic
{
    public class Login
    {
        private readonly LoginService loginService; // Use LoginService instead of Service
        public Login()
        {
            loginService = new LoginService(); // Initialize LoginService
        }
        public bool LogIn(string username, string password)
        {
            return loginService.LogIn(username, password); // Call LogIn on LoginService
        }
    }
}