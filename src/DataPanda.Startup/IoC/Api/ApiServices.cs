using Microsoft.Extensions.DependencyInjection;

namespace DataPanda.Startup.IoC.Api
{
    public static class ApiServices
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddControllers();

            return services;
        }
    }
}
