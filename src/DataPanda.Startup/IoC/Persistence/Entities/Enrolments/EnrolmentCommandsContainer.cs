using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Enrolments.Commands.Create;
using DataPanda.Persistence.Entities.Enrolments.Commands.Create;

namespace DataPanda.Startup.IoC.Persistence.Entities.Enrolments
{
    public static class EnrolmentCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateEnrolmentPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
