using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.EnrolmentWikis.Queries.GetByWikiAndEnrolmentIds;
using DataPanda.Domain.Entities;
using DataPanda.Persistence.Entities.EnrolmentWikis.Queries.GetByWikiAndEnrolmentIds;

namespace DataPanda.Startup.IoC.Persistence.Entities.EnrolmentWikis
{
    public static class EnrolmentWikiQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGeBWikiAndEnrolmentIds(builder);
        }

        private static void RegisterGeBWikiAndEnrolmentIds(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetEnrolmentWikiByWikiAndEnrolmentIdsPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetEnrolmentWikiByWikiAndEnrolmentIdsPersistenceQuery, EnrolmentWiki>>()
                .InstancePerLifetimeScope();
        }
    }
}
