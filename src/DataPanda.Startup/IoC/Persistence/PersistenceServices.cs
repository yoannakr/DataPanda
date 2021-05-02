using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Courses.Commands.Create;
using DataPanda.Application.Persistence.Courses.Queries.GetByName;
using DataPanda.Application.Persistence.Enrolments.Commands.Create;
using DataPanda.Application.Persistence.Enrolments.Queries.GetForStudent;
using DataPanda.Application.Persistence.LearningPlatforms.Commands.Create;
using DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType;
using DataPanda.Domain.Entities;
using DataPanda.Persistence;
using DataPanda.Persistence.Entities.Courses.Commands.Create;
using DataPanda.Persistence.Entities.Courses.Queries.GetByName;
using DataPanda.Persistence.Entities.Enrolments.Commands.Create;
using DataPanda.Persistence.Entities.Enrolments.Queries.GetForStudent;
using DataPanda.Persistence.Entities.LearningPlatforms.Commands.Create;
using DataPanda.Persistence.Entities.LearningPlatforms.Queries.GetByNameAndType;
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
                .AddCommands()
                .AddQueries();

        private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<DataPandaDbContext>(options
                => options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    sqlServer => sqlServer.MigrationsAssembly(typeof(DataPandaDbContext).Assembly.FullName)));

        private static IServiceCollection AddCommands(this IServiceCollection services)
            => services
                .AddScoped<IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result>, CreateCoursePersistenceCommandHandler>()
                .AddScoped<IPersistenceCommandHandler<CreateLearningPlatformPersistenceCommand, Result>, CreateLearningPlatformPersistenceCommandHandler>()
                .AddScoped<IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result>, CreateEnrolmentPersistenceCommandHandler>();

        private static IServiceCollection AddQueries(this IServiceCollection services)
            => services
                .AddScoped<IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course>, GetCourseByNamePersistenceQueryHandler>()
                .AddScoped<IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform>, GetLearningPlatformByNameAndTypePersistenceQueryHandler>()
                .AddScoped<IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment>, GetEnrolmentForStudentPersistenceQueryHandler>();
    }
}
