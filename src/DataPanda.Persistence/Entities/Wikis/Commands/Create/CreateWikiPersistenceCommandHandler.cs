using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Wikis.Commands.Create;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Wikis.Commands.Create
{
    public class CreateWikiPersistenceCommandHandler : IPersistenceCommandHandler<CreateWikiPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public CreateWikiPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(CreateWikiPersistenceCommand command)
        {
            await context.Wikis.AddAsync(command.Wiki);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
