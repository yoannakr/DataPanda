using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Students.Queries.GetById;
using DataPanda.Domain.Entities;
using DataPanda.Persistence.Entities.Students.Queries.GetById;

namespace DataPanda.Startup.IoC.Persistence.Entities.Students
{
    public static class StudentsQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGetById(builder);
        }

        private static void RegisterGetById(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetStudentByIdPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student>>()
                .InstancePerLifetimeScope();
        }
    }
}
