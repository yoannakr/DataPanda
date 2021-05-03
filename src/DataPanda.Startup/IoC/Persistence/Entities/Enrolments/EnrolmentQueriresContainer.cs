using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Enrolments.Queries.GetForStudent;
using DataPanda.Domain.Entities;
using DataPanda.Persistence.Entities.Enrolments.Queries.GetForStudent;

namespace DataPanda.Startup.IoC.Persistence.Entities.Enrolments
{
    public static class EnrolmentQueriresContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGetForStudent(builder);
        }

        private static void RegisterGetForStudent(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetEnrolmentForStudentPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment>>()
                .InstancePerLifetimeScope();
        }
    }
}
