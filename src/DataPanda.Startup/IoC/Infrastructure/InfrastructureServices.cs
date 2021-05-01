using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using DataPanda.Infrastructure.Parsers;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Text;

namespace DataPanda.Startup.IoC.Infrastructure
{
    public static class InfrastructureServices
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddScoped<IParser<IEnumerable<StudentResult>>, StudentResultParser>()
                .AddScoped<IParser<StudentActivity>, StudentActivityParser>();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            return services;
        }
    }
}
