using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using System.IO;

namespace DataPanda.Application.Features.Files.Commands.Upload
{
    public class UploadFileCommand : ICommand<Result>
    {
        public UploadFileCommand(Stream fileStream)
        {
            FileStream = fileStream;
        }

        public Stream FileStream { get; }
    }
}
