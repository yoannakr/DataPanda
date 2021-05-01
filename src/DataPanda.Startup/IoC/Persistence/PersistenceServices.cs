using DataPanda.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataPanda.Startup.IoC.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
            => services.AddDatabase(configuration);

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<DataPandaDbContext>(options
                => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServer => sqlServer.MigrationsAssembly(typeof(DataPandaDbContext).Assembly.FullName)));
    }
}
