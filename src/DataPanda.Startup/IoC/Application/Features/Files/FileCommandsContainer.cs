using Autofac;
using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Features.Files.Commands.Upload;
using DataPanda.Application.Features.Files.Commands.UploadArchive;
using DataPanda.Application.Features.Files.Commands.UploadMultiple;
using DataPanda.Application.Features.Files.Common.Commands.Decorators;
using DataPanda.Application.Features.Files.Common.Commands.Process;

namespace DataPanda.Startup.IoC.Application.Features.Files
{
    public static class FileCommandsContainer
    {
        public static void Register(ContainerBuilder builder)
        {
            RegisterUpload(builder);
            RegisterUploadMultiple(builder);
            RegisterUploadArchive(builder);
            RegisterCommonProcess(builder);
        }

        private static void RegisterUpload(ContainerBuilder builder)
        {
            builder
                .RegisterType<UploadFileCommandHandler>()
                .As<ICommandHandler<UploadFileCommand, Result>>()
                .InstancePerLifetimeScope();

            builder
               .RegisterDecorator<EnsureLearningPlatformExistsCommandDecorator<UploadFileCommand>, ICommandHandler<UploadFileCommand, Result>>();

            builder
                .RegisterDecorator<EnsureCourseExistsCommandDecorator<UploadFileCommand>, ICommandHandler<UploadFileCommand, Result>>();
        }

        private static void RegisterUploadMultiple(ContainerBuilder builder)
        {
            builder
                .RegisterType<UploadMultipleFilesCommandHandler>()
                .As<ICommandHandler<UploadMultipleFilesCommand, Result>>()
                .InstancePerLifetimeScope();

            builder
               .RegisterDecorator<EnsureLearningPlatformExistsCommandDecorator<UploadMultipleFilesCommand>, ICommandHandler<UploadMultipleFilesCommand, Result>>();

            builder
                .RegisterDecorator<EnsureCourseExistsCommandDecorator<UploadMultipleFilesCommand>, ICommandHandler<UploadMultipleFilesCommand, Result>>();
        }

        private static void RegisterUploadArchive(ContainerBuilder builder)
        {
            builder
                .RegisterType<UploadFileArchiveCommandHandler>()
                .As<ICommandHandler<UploadFileArchiveCommand, Result>>()
                .InstancePerLifetimeScope();

            builder
               .RegisterDecorator<EnsureLearningPlatformExistsCommandDecorator<UploadFileArchiveCommand>, ICommandHandler<UploadFileArchiveCommand, Result>>();

            builder
                .RegisterDecorator<EnsureCourseExistsCommandDecorator<UploadFileArchiveCommand>, ICommandHandler<UploadFileArchiveCommand, Result>>();
        }

        private static void RegisterCommonProcess(ContainerBuilder builder)
        {
            builder
                .RegisterType<ProcessStudentResultFileCommandHandler>()
                .As<ICommandHandler<ProcessFileCommand, Result>>()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<ProcessStudentActivityFileCommandHandler>()
                .As<ICommandHandler<ProcessFileCommand, Result>>()
                .InstancePerLifetimeScope();
        }
    }
}
