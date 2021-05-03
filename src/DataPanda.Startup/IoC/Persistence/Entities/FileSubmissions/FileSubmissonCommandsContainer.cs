using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.FileSubmissions.Commands.Create;
using DataPanda.Persistence.Entities.FileSubmissions.Commands.Create;

namespace DataPanda.Startup.IoC.Persistence.Entities.FileSubmissions
{
    public class FileSubmissonCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateFileSubmissionPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateFileSubmissionPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
