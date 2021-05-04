using DataPanda.Application.Features.Files.Common.Commands;
using System.IO;

namespace DataPanda.Application.Features.Files.Commands.UploadArchive
{
    public class UploadFileArchiveCommand : FileCommand
    {
        public UploadFileArchiveCommand(
            string platformName,
            string platformType,
            string platformUrl,
            string courseName,
            string courseFieldOfApplication,
            Stream archiveFileStream)
            : base(platformName, platformType, platformUrl, courseName, courseFieldOfApplication)
        {
            ArchiveFileStream = archiveFileStream;
        }

        public Stream ArchiveFileStream { get; }
    }
}
