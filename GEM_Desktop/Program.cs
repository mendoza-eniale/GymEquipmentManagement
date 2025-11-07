using System;
using System.Windows.Forms;

namespace GEM_Desktop
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var config = new EConfiguration
            {
                SmtpServer = "smtp.example.com",
                Port = 2525,
                SenderEmail = "do-not-reply@example.com",
                Password = "password123"
            };

            EmailService.AddEmailService(config);

            Application.Run(new Login());
        }
    }

    public class EConfiguration
    {
        public string SmtpServer { get; set; }
        public int Port { get; set; }
        public string SenderEmail { get; set; }
        public string Password { get; set; }
    }

    public static class EmailService
    {
        public static void AddEmailService(EConfiguration config)
        {
            MessageBox.Show($"Email service initialized for {config.SenderEmail}");
        }
    }
}
