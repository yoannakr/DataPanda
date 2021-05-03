using Autofac;
using DataPanda.Startup.IoC.Application.Features;

namespace DataPanda.Startup.IoC.Application
{
    public static class ApplicationContainer
    {
        public static ContainerBuilder RegisterApplication(this ContainerBuilder builder)
        {
            FeaturesCqrsContainer.Register(builder);

            return builder;
        }
    }
}
