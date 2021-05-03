using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Features.Files.Commands.Upload;

namespace DataPanda.Startup.IoC.Application.Features.Files
{
    public static class FileCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterUpload(builder);
        }

        private static void RegisterUpload(ContainerBuilder builder)
        {
            builder
                .RegisterType<UploadFileCommandHandler>()
                .As<ICommandHandler<UploadFileCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
