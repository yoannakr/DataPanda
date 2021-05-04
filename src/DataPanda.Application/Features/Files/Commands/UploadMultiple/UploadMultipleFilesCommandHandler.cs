using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Features.Files.Common.Commands.Process;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Commands.UploadMultiple
{
    public class UploadMultipleFilesCommandHandler : ICommandHandler<UploadMultipleFilesCommand, Result>
    {
        private readonly IEnumerable<ICommandHandler<ProcessFileCommand, Result>> processFileCommandHandlers;

        public UploadMultipleFilesCommandHandler(IEnumerable<ICommandHandler<ProcessFileCommand, Result>> processFileCommandHandlers)
        {
            this.processFileCommandHandlers = processFileCommandHandlers;
        }

        public async Task<Result> Handle(UploadMultipleFilesCommand command)
        {
            foreach (var fileStream in command.FileStreams)
            {
                var processFileCommand = new ProcessFileCommand(fileStream, command.CourseName, command.PlatformName, command.PlatformType);
                foreach (var processFileCommandHandler in processFileCommandHandlers)
                {
                    await processFileCommandHandler.Handle(processFileCommand);
                }
            }

            return Result.Success();
        }
    }
}
