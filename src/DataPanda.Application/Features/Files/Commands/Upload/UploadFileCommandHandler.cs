using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Features.Files.Common.Commands.Process;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Commands.Upload
{
    public class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, Result>
    {
        private readonly IEnumerable<ICommandHandler<ProcessFileCommand, Result>> processFileCommandHandlers;

        public UploadFileCommandHandler(IEnumerable<ICommandHandler<ProcessFileCommand, Result>> processFileCommandHandlers)
        {
            this.processFileCommandHandlers = processFileCommandHandlers;
        }

        public async Task<Result> Handle(UploadFileCommand command)
        {
            var processFileCommand = new ProcessFileCommand(command.FileStream, command.CourseName, command.PlatformName, command.PlatformType);
            foreach (var processFileCommandHandler in processFileCommandHandlers)
            {
                await processFileCommandHandler.Handle(processFileCommand);
            }

            return Result.Success();
        }
    }
}
