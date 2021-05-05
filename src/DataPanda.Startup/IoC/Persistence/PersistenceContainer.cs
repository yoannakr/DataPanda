using Autofac;
using DataPanda.Startup.IoC.Persistence.Entities;
using DataPanda.Startup.IoC.Persistence.Statistics;

namespace DataPanda.Startup.IoC.Persistence
{
    public static class PersistenceContainer
    {
        public static ContainerBuilder RegisterPersistence(this ContainerBuilder builder)
        {
            EntitiesCqrsContainer.Register(builder);
            StatisticsCqrsConteiner.Register(builder);

            return builder;
        }
    }
}
