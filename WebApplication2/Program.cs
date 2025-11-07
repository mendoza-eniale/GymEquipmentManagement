using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using GEMCommon.Contracts;

namespace GymEquipmentManagement.Services
{
    public static class EmailServiceExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEmailService>(sp =>
            {
                var smtpServer = configuration["Email:SmtpServer"];
                var port = int.Parse(configuration["2525"]);
                var senderEmail = configuration["elainejoymendoza0904@gmail.com"];
                var password = configuration["d2fb956416cc4b"];

                return new EmailService(smtpServer, port, senderEmail, password);
            });

            return services;
        }
    }
}
