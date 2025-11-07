using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GEMCommon { 
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string subject, string htmlBody, string plainBody = null);
    }
    public class EmailService
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string From { get; set; }
        public string FromName { get; set; }
    }
}