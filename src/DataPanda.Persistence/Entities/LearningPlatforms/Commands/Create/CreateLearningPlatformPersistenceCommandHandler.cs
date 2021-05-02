using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.LearningPlatforms.Commands.Create;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.LearningPlatforms.Commands.Create
{
    public class CreateLearningPlatformPersistenceCommandHandler : IPersistenceCommandHandler<CreateLearningPlatformPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public CreateLearningPlatformPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(CreateLearningPlatformPersistenceCommand command)
        {
            await context.LearningPlatforms.AddAsync(command.LearningPlatform);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
