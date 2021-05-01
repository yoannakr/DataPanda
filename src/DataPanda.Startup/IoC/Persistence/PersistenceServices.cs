using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Courses.Commands.Create;
using DataPanda.Persistence;
using DataPanda.Persistence.Entities.Courses.Commands.Create;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataPanda.Startup.IoC.Persistence
{
    public static class PersistenceServices
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
            => services
                .AddDatabase(configuration)
                .AddCommands();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<DataPandaDbContext>(options
                => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServer => sqlServer.MigrationsAssembly(typeof(DataPandaDbContext).Assembly.FullName)));

        private static IServiceCollection AddCommands(this IServiceCollection services)
            => services.AddScoped<IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result>, CreateCoursePersistenceCommandHandler>();
    }
}
