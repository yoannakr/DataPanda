using Autofac;
using DataPanda.Startup.IoC.Application.Features.Files;
using DataPanda.Startup.IoC.Application.Features.Statistics;

namespace DataPanda.Startup.IoC.Application.Features
{
    public static class FeaturesCqrsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterFileCqrs(builder);
            RegisterStatisticsCqrs(builder);
        }

        private static void RegisterFileCqrs(ContainerBuilder builder)
        {
            FileCommandsContainer.Register(builder);
        }

        private static void RegisterStatisticsCqrs(ContainerBuilder builder)
        {
            StatisticsQueriesContainer.Register(builder);
        }
    }
}
