using Autofac;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using DataPanda.Infrastructure.Parsers;
using System.Collections.Generic;

namespace DataPanda.Startup.IoC.Infrastructure.Parsers
{
    public static class ParsersContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            builder
                .RegisterType<StudentResultParser>()
                .As<IParser<IEnumerable<StudentResult>>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<StudentActivityParser>()
                .As<IParser<IEnumerable<StudentActivity>>>()
                .InstancePerLifetimeScope();
        }
    }
}
