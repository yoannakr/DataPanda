using Autofac;
using DataPanda.Startup.IoC.Application.Features.Files;

namespace DataPanda.Startup.IoC.Application.Features
{
    public static class FeaturesCqrsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterFileCqrs(builder);
        }

        private static void RegisterFileCqrs(ContainerBuilder builder)
        {
            FileCommandsContainer.Register(builder);
        }
    }
}
