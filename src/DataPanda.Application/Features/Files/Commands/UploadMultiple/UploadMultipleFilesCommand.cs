using DataPanda.Application.Features.Files.Common.Commands;
using System.Collections.Generic;
using System.IO;

namespace DataPanda.Application.Features.Files.Commands.UploadMultiple
{
    public class UploadMultipleFilesCommand : FileCommand
    {
        public UploadMultipleFilesCommand(
            string platformName,
            string platformType,
            string platformUrl,
            string courseName,
            string courseFieldOfApplication,
            IEnumerable<Stream> fileStreams)
            : base(platformName, platformType, platformUrl, courseName, courseFieldOfApplication)
        {
            FileStreams = fileStreams;
        }

        public IEnumerable<Stream> FileStreams { get; }
    }
}
