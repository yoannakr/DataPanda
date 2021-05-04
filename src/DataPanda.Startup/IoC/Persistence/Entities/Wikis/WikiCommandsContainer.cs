using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Wikis.Commands.Create;
using DataPanda.Persistence.Entities.Wikis.Commands.Create;

namespace DataPanda.Startup.IoC.Persistence.Entities.Wikis
{
    public static class WikiCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateWikiPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateWikiPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
