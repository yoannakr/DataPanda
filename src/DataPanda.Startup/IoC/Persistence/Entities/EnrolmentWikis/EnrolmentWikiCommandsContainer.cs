using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.EnrolmentWikis.Commands.Create;
using DataPanda.Application.Persistence.EnrolmentWikis.Commands.Update;
using DataPanda.Persistence.Entities.EnrolmentWikis.Commands.Create;
using DataPanda.Persistence.Entities.EnrolmentWikis.Commands.Update;

namespace DataPanda.Startup.IoC.Persistence.Entities.EnrolmentWikis
{
    public static class EnrolmentWikiCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterCreate(builder);
            RegisterUpdate(builder);
        }

        private static void RegisterCreate(ContainerBuilder builder)
        {
            builder
                .RegisterType<CreateEnrolmentWikiPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<CreateEnrolmentWikiPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterUpdate(ContainerBuilder builder)
        {
            builder
                .RegisterType<UpdateEnrolmentWikiPersistenceCommandHandler>()
                .As<IPersistenceCommandHandler<UpdateEnrolmentWikiPersistenceCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
