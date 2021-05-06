﻿using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;

namespace DataPanda.Startup.IoC.Application.Features.Statistics
{
    public static class StatisticsQueriesContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterGetFrequencyDistribution(builder);
            RegisterGetCentralTrend(builder);
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
    }
}
