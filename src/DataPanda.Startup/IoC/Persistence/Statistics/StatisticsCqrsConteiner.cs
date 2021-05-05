﻿using Autofac;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetFrequencyDistribution;
using DataPanda.Persistence.Features.Statistics.Queries.GetFrequencyDistribution;

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
        }
    }
}
