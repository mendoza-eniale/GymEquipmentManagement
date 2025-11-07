using GymEquipmentManagement.Services;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace GEM_Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new Login()); 
            EmailService.AddEmailService(EConfiguration);
        }
    }
}
