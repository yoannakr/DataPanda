using Autofac;
using DataPanda.Startup.IoC.Persistence.Entities;

namespace DataPanda.Startup.IoC.Persistence
{
    public static class PersistenceContainer
    {
        public static ContainerBuilder RegisterPersistence(this ContainerBuilder builder)
        {
            EntitiesCqrsContainer.Register(builder);

            return builder;
        }
    }
}
