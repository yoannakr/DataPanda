using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using System.IO;

namespace DataPanda.Application.Features.Files.Commands.Upload
{
    public class UploadFileCommand : ICommand<Result>
    {
        public UploadFileCommand(
            Stream fileStream,
            string platformName,
            string platformType,
            string platformUrl,
            string courseName,
            string courseFieldOfApplication)
        {
            FileStream = fileStream;
            PlatformName = platformName;
            PlatformType = platformType;
            PlatformUrl = platformUrl;
            CourseName = courseName;
            CourseFieldOfApplication = courseFieldOfApplication;
        }

        public Stream FileStream { get; }

        public string PlatformName { get; }

        public string PlatformType { get; }

        public string PlatformUrl { get; }

        public string CourseName { get; }

        public string CourseFieldOfApplication { get; }
    }
}
