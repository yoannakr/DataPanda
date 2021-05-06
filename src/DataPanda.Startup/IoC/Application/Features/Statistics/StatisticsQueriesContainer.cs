using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;
using DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis;
using DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis.Models;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;
using DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures;
using DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures.Models;

namespace DataPanda.Startup.IoC.Application.Features.Statistics
{
    public static class StatisticsQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGetFrequencyDistribution(builder);
            RegisterGetCentralTrend(builder);
            RegisterGetScatteringMeasures(builder);
            RegisterGetCorrelationAnalysis(builder);
        }

        private static void RegisterGetFrequencyDistribution(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetFrequencyDistributionQueryHandler>()
                .As<IQueryHandler<GetFrequencyDistributionQuery, FrequencyDistributionOutputModel>>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterGetCentralTrend(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetCentralTrendQueryHandler>()
                .As<IQueryHandler<GetCentralTrendQuery, CentralTrendOutputModel>>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterGetScatteringMeasures(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetScatteringMeasuresQueryHandler>()
                .As<IQueryHandler<GetScatteringMeasuresQuery, ScatteringMeasuresOutputModel>>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterGetCorrelationAnalysis(ContainerBuilder builder)
        {
            builder
                .RegisterType<GetCorrelationAnalysisQueryHandler>()
                .As<IQueryHandler<GetCorrelationAnalysisQuery, CorrelationAnalysisOutputModel>>()
                .InstancePerLifetimeScope();
        }
    }
}
