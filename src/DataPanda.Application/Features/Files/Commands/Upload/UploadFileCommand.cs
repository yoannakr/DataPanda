using DataPanda.Application.Features.Files.Common.Commands;
using System.IO;

namespace DataPanda.Application.Features.Files.Commands.Upload
{
    public class UploadFileCommand : FileCommand
    {
        public UploadFileCommand(
            string platformName,
            string platformType,
            string platformUrl,
            string courseName,
            string courseFieldOfApplication,
            Stream fileStream)
            : base(platformName, platformType, platformUrl, courseName, courseFieldOfApplication)
        {
            FileStream = fileStream;
        }

        public Stream FileStream { get; }
    }
}
