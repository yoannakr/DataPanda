using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType;
using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.LearningPlatforms.Queries.GetByNameAndType
{
    public class GetLearningPlatformByNameAndTypePersistenceQueryHandler : IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform>
    {
        private readonly DataPandaDbContext context;

        public GetLearningPlatformByNameAndTypePersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<LearningPlatform> Handle(GetLearningPlatformByNameAndTypePersistenceQuery query)
            => await context.LearningPlatforms.FirstOrDefaultAsync(
                platform => platform.Name == query.Name && platform.Type == query.Type);
    }
}
