using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Configuration;
using System.Threading.Tasks;

namespace GymEquipmentManagement.Services
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

    public class EmailService : IEmailService
    {
        private readonly SmtpSettings _settings;

        public EmailService(IOptions<SmtpSettings> smtpSettings)
        {
            _settings = smtpSettings.Value ?? throw new ArgumentNullException(nameof(smtpSettings));
        }

        public async Task SendEmailAsync(string to, string subject, string htmlBody, string plainBody = null)
        {
            if (string.IsNullOrWhiteSpace(to))
                throw new ArgumentException("Recipient is required", nameof(to));

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_settings.FromName, _settings.From));
            message.To.Add(MailboxAddress.Parse(to));
            message.Subject = subject ?? string.Empty;

            var builder = new BodyBuilder();

            
            if (!string.IsNullOrWhiteSpace(htmlBody))
                builder.HtmlBody = htmlBody;

            if (!string.IsNullOrWhiteSpace(plainBody))
                builder.TextBody = plainBody;
            else if (!string.IsNullOrWhiteSpace(htmlBody))
                builder.TextBody = "Please view this email in an HTML-compatible email client.";
            else
                builder.TextBody = string.Empty;

            message.Body = builder.ToMessageBody();

           
            using var client = new SmtpClient();

            SecureSocketOptions secureOption = _settings.Port == 465
                ? SecureSocketOptions.SslOnConnect
                : SecureSocketOptions.StartTls;

            try
            {
                await client.ConnectAsync(_settings.Host, _settings.Port, secureOption).ConfigureAwait(false);

                if (!string.IsNullOrWhiteSpace(_settings.Username))
                {
                    await client.AuthenticateAsync(_settings.Username, _settings.Password).ConfigureAwait(false);
                }

                await client.SendAsync(message).ConfigureAwait(false);
            }
            finally
            {
                await client.DisconnectAsync(true).ConfigureAwait(false);
            }
        }
    }

    public static class EmailServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));

            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}