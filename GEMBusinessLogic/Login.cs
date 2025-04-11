using GEMDataAccess;
using System;

namespace GEMBusinessLogic
{
    public class Login
    {
        private Service service;

        public Login()
        {
            service = new Service();
        }

        public bool LogIn(string username, string password)
        {
            return service.GetStorage().LogIn(username, password);
        }
    }
}
