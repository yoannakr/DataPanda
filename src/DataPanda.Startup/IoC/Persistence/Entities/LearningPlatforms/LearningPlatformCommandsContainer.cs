using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.LearningPlatforms.Commands.Create;
using DataPanda.Persistence.Entities.LearningPlatforms.Commands.Create;

namespace DataPanda.Startup.IoC.Persistence.Entities.LearningPlatforms
{
    public class LearningPlatformCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateLearningPlatformPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateLearningPlatformPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
