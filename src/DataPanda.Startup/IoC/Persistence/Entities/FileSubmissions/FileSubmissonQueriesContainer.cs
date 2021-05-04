using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.FileSubmissions.Queries.GetById;
using DataPanda.Domain.Entities;
using DataPanda.Persistence.Entities.FileSubmissions.Queries.GetById;

namespace DataPanda.Startup.IoC.Persistence.Entities.FileSubmissions
{
    public static class FileSubmissonQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGetById(builder);
        }

        private static void RegisterGetById(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetFileSubmissionByIdPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetFileSubmissionByIdPersistenceQuery, FileSubmission>>()
                .InstancePerLifetimeScope();
        }
    }
}
