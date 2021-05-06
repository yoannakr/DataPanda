using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;
using DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetCentralTrend;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetFrequencyDistribution;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetScatteringMeasures;
using DataPanda.Persistence.Features.Statistics.Queries.GetCentralTrendQuery;
using DataPanda.Persistence.Features.Statistics.Queries.GetFrequencyDistribution;
using DataPanda.Persistence.Features.Statistics.Queries.GetScatteringMeasures;

namespace DataPanda.Startup.IoC.Persistence.Statistics
{
    public static class StatisticsCqrsConteiner
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterQueries(builder);
        }

        private static void RegisterQueries(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetFrequencyDistributionPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetFrequencyDistributionPersistenceQuery, FrequencyDistributionOutputModel>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<GetCentralTrendPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetCentralTrendPersistenceQuery, CentralTrendOutputModel>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<GetScatteringMeasuresPersistenceQueryHandler>()
                .As<IPersistenceQueryHandler<GetScatteringMeasuresPersistenceQuery, ScatteringMeasuresOutputModel>>()
                .InstancePerLifetimeScope();
        }
    }
}
