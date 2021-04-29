using Microsoft.Extensions.DependencyInjection;

namespace DataPanda.Api
{
    public static class ApiServicesConfiguration
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services
                .AddControllers();

            return services;
        }
    }
}
