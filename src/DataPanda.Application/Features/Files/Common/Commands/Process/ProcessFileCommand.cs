using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using System.IO;

namespace DataPanda.Application.Features.Files.Common.Commands.Process
{
    public class ProcessFileCommand : ICommand<Result>
    {
        public ProcessFileCommand(
            Stream fileStream,
            string courseName,
            string learningPlatformName,
            string learningPlatformType)
        {
            FileStream = fileStream;
            CourseName = courseName;
            LearningPlatformName = learningPlatformName;
            LearningPlatformType = learningPlatformType;
        }

        public Stream FileStream { get; }

        public string CourseName { get; }

        public string LearningPlatformName { get; }

        public string LearningPlatformType { get; }
    }
}
