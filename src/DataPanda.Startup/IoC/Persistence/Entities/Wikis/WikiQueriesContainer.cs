using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Wikis.Commands.Queries.GetById;
using DataPanda.Domain.Entities;
using DataPanda.Persistence.Entities.Wikis.Queries.GetById;

namespace DataPanda.Startup.IoC.Persistence.Entities.Wikis
{
    public static class WikiQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGetById(builder);
        }

        private static void RegisterGetById(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetWikiByIdPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetWikiByIdPersistenceQuery, Wiki>>()
                .InstancePerLifetimeScope();
        }
    }
}
