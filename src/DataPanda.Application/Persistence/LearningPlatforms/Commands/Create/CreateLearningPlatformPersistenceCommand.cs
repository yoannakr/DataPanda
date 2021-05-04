using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.LearningPlatforms.Commands.Create
{
    public class CreateLearningPlatformPersistenceCommand : IPersistenceCommand<Result>
    {
        public CreateLearningPlatformPersistenceCommand(LearningPlatform learningPlatform)
        {
            LearningPlatform = learningPlatform;
        }

        public LearningPlatform LearningPlatform { get; set; }
    }
}
