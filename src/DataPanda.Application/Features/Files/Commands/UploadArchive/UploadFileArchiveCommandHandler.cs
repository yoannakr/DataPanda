using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Features.Files.Common.Commands.Process;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Commands.UploadArchive
{
    public class UploadFileArchiveCommandHandler : ICommandHandler<UploadFileArchiveCommand, Result>
    {
        private readonly IEnumerable<ICommandHandler<ProcessFileCommand, Result>> processFileCommandHandlers;

        public UploadFileArchiveCommandHandler(IEnumerable<ICommandHandler<ProcessFileCommand, Result>> processFileCommandHandlers)
        {
            this.processFileCommandHandlers = processFileCommandHandlers;
        }

        public async Task<Result> Handle(UploadFileArchiveCommand command)
        {
            using var memoryStream = new MemoryStream();
            await command.ArchiveFileStream.CopyToAsync(memoryStream);

            using var archive = new ZipArchive(memoryStream);
            foreach (var archiveEntry in archive.Entries)
            {
                using var archiveStream = archiveEntry.Open();

                using var fileStream = new MemoryStream();
                await archiveStream.CopyToAsync(fileStream);

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
