using DataPanda.Application.Contracts.Parsers;
using DataPanda.Infrastructure.Parsers;
using Microsoft.Extensions.DependencyInjection;
using System.Text;

namespace DataPanda.Infrastructure
{
    public static class InfrastructureServicesConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddScoped<IStudentResultParser, StudentResultParser>()
                .AddScoped<IStudentActivityParser, StudentActivityParser>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            return services;
        }

    }
}
