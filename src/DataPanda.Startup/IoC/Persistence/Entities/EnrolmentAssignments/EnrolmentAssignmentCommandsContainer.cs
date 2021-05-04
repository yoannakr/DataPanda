using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.EnrolmentAssignments.Commands.Create;
using DataPanda.Persistence.Entities.EnrolmentAssignments.Commands.Create;

namespace DataPanda.Startup.IoC.Persistence.Entities.EnrolmentAssignments
{
    public class EnrolmentAssignmentCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateEnrolmentAssignmentPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateEnrolmentAssignmentPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
