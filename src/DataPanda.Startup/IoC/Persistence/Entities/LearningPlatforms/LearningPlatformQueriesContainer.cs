using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType;
using DataPanda.Domain.Entities;
using DataPanda.Persistence.Entities.LearningPlatforms.Queries.GetByNameAndType;

namespace DataPanda.Startup.IoC.Persistence.Entities.LearningPlatforms
{
    public static class LearningPlatformQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGetByNameAndType(builder);
        }

        private static void RegisterGetByNameAndType(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetLearningPlatformByNameAndTypePersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform>>()
                .InstancePerLifetimeScope();
        }
    }
}
