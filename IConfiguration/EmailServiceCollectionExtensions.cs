using GEMCommon.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Impl = GEMBusinessLogic.Services;

namespace GymEquipmentManagement.Configuration
{
    public static class EmailServiceCollectionExtensions
    {
        public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
            services.AddTransient<IEmailService, Impl.EmailService>();
            return services;
        }
    }
}
