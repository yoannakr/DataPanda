using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Courses.Commands.Create;
using DataPanda.Persistence.Entities.Courses.Commands.Create;

namespace DataPanda.Startup.IoC.Persistence.Entities.Courses
{
    public static class CourseCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateCoursePersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
