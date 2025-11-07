//using GEMBusinessLogic.Services;
//using GEMCommon.Contracts;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace GymEquipmentManagement.Configuration
//{
//    public static class EmailServiceCollectionExtensions
//    {
//        public static IServiceCollection AddEmailService(this IServiceCollection services, IConfiguration configuration)
//        {
//            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));
//            services.AddTransient<IEmailService, EmailService>();

//            return services;
//        }
//    }
//}