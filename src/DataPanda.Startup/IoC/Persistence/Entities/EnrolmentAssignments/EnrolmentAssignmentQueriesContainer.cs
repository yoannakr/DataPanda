using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.EnrolmentAssignments.Queries.GetByAssignmentAndEnrolmentIds;
using DataPanda.Domain.Entities;
using DataPanda.Persistence.Entities.EnrolmentAssignments.Queries.GeByAssignmentAndEnrolmentIds;

namespace DataPanda.Startup.IoC.Persistence.Entities.EnrolmentAssignments
{
    public static class EnrolmentAssignmentQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGeByAssignmentAndEnrolmentIds(builder);
        }

        private static void RegisterGeByAssignmentAndEnrolmentIds(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQuery, EnrolmentAssignment>>()
                .InstancePerLifetimeScope();
        }
    }
}
