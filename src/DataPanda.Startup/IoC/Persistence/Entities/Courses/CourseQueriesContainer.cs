using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Courses.Queries.GetByName;
using DataPanda.Domain.Entities;
using DataPanda.Persistence.Entities.Courses.Queries.GetByName;

namespace DataPanda.Startup.IoC.Persistence.Entities.Courses
{
    public static class CourseQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGetByName(builder);
        }

        private static void RegisterGetByName(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetCourseByNamePersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course>>()
                .InstancePerLifetimeScope();
        }
    }
}
