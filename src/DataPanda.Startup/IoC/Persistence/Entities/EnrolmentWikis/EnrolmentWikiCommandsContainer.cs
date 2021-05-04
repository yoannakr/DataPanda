using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.EnrolmentWikis.Commands.Create;
using DataPanda.Persistence.Entities.EnrolmentWikis.Commands.Create;

namespace DataPanda.Startup.IoC.Persistence.Entities.EnrolmentWikis
{
    public static class EnrolmentWikiCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateEnrolmentWikiPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateEnrolmentWikiPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
