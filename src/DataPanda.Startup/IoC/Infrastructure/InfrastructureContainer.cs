using Autofac;
using DataPanda.Startup.IoC.Infrastructure.Parsers;
using System.Text;

namespace DataPanda.Startup.IoC.Infrastructure
{
    public static class InfrastructureContainer
    {
        public static ContainerBuilder RegisterInfrastructure(this ContainerBuilder builder)
        {
            ParsersContainer.Register(builder);

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            return builder;
        }
    }
}
