using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType
{
    public class GetLearningPlatformByNameAndTypePersistenceQuery : IPersistenceQuery<LearningPlatform>
    {
        public GetLearningPlatformByNameAndTypePersistenceQuery(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; }

        public string Type { get; }
    }
}
