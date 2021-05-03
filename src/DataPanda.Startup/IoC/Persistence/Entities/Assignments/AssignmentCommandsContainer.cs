using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Assignments.Commands.Create;
using DataPanda.Persistence.Entities.Assignments.Commands.Create;

namespace DataPanda.Startup.IoC.Persistence.Entities.Assignments
{
    public static class AssignmentCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateAssignmentPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateAssignmentPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
