using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.FileSubmissions.Commands.Create;
using DataPanda.Application.Persistence.FileSubmissions.Commands.Update;
using DataPanda.Persistence.Entities.FileSubmissions.Commands.Create;
using DataPanda.Persistence.Entities.FileSubmissions.Commands.Update;

namespace DataPanda.Startup.IoC.Persistence.Entities.FileSubmissions
{
    public class FileSubmissonCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
            RegisterUpdate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateFileSubmissionPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateFileSubmissionPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterUpdate(ContainerBuilder builder)
        {
            builder
                .RegisterType<UpdateFileSubmissionPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<UpdateFileSubmissionPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
