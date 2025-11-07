using System.Threading.Tasks;

namespace GEMCommon.Contracts
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string htmlBody, string plainBody = null);
    }

    public class SmtpSettings
    {
        public string Host { get; set; } = "sandbox.smtp.mailtrap.io";
        public int Port { get; set; } = 2525;
        public string Username { get; set; } = "16f6603510d4bb";  
        public string Password { get; set; } = "d2fb956416cc4b";  
        public string From { get; set; } = "elainejoymendoza0904@gmail.com";
        public string FromName { get; set; } = "No Reply";
    }
}
