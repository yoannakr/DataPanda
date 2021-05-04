using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Assignments.Queries.GetById;
using DataPanda.Domain.Entities;
using DataPanda.Persistence.Entities.Assignments.Queries.GetById;

namespace DataPanda.Startup.IoC.Persistence.Entities.Assignments
{
    public static class AssignmentQueryContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGetById(builder);
        }

        private static void RegisterGetById(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetAssignmentByIdPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetAssignmentByIdPersistenceQuery, Assignment>>()
                .InstancePerLifetimeScope();
        }
    }
}
