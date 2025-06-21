
using GEMCommon;

namespace GEMBusinessLogic
{
    public class Login
    {
        private readonly LoginService loginService;

        public Login()
        {
            loginService = new LoginService();
        }

        public bool LogIn(string username, string password)
        {
            return loginService.LogIn(username, password);
        }
    }
}
