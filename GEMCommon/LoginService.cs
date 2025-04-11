
namespace GEMDataAccess
{
    public class LoginService
    {
        private string username = "admin";
        private string password = "123456";

        public bool LogIn(string inputUsername, string inputPassword)
        {
            if (inputUsername == username && inputPassword == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
