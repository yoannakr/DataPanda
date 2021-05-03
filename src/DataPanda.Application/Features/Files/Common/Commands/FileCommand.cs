using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;

namespace DataPanda.Application.Features.Files.Common.Commands
{
    public abstract class FileCommand : ICommand<Result>
    {
        protected FileCommand(
            string platformName,
            string platformType,
            string platformUrl,
            string courseName,
            string courseFieldOfApplication)
        {
            PlatformName = platformName;
            PlatformType = platformType;
            PlatformUrl = platformUrl;
            CourseName = courseName;
            CourseFieldOfApplication = courseFieldOfApplication;
        }

        public string PlatformName { get; }

        public string PlatformType { get; }

        public string PlatformUrl { get; }

        public string CourseName { get; }

        public string CourseFieldOfApplication { get; }
    }
}
