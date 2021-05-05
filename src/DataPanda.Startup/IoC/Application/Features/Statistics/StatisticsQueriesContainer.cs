using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;

namespace DataPanda.Startup.IoC.Application.Features.Statistics
{
    public static class StatisticsQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterUpload(builder);
        }

        private static void RegisterUpload(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetFrequencyDistributionQueryHandler>()
                .As<IQueryHandler<GetFrequencyDistributionQuery, FrequencyDistributionOutputModel>>()
                .InstancePerLifetimeScope();
        }
    }
}
