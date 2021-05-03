using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Students.Commands.Create;
using DataPanda.Persistence.Entities.Students.Commands.Create;

namespace DataPanda.Startup.IoC.Persistence.Entities.Students
{
    public static class StudentCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateStudentPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateStudentPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
