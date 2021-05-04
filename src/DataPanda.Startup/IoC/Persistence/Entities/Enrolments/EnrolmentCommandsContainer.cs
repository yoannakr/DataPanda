using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Enrolments.Commands.Create;
using DataPanda.Application.Persistence.Enrolments.Commands.Update;
using DataPanda.Persistence.Entities.Enrolments.Commands.Create;
using DataPanda.Persistence.Entities.Enrolments.Commands.Update;

namespace DataPanda.Startup.IoC.Persistence.Entities.Enrolments
{
    public static class EnrolmentCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
            RegisterUpdate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateEnrolmentPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterUpdate(ContainerBuilder builder)
        {
            builder
                .RegisterType<UpdateEnrolmentPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<UpdateEnrolmentPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
