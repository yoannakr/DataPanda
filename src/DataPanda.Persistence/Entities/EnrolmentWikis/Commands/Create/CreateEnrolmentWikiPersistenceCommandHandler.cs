using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.EnrolmentWikis.Commands.Create;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.EnrolmentWikis.Commands.Create
{
    public class CreateEnrolmentWikiPersistenceCommandHandler : IPersistenceCommandHandler<CreateEnrolmentWikiPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public CreateEnrolmentWikiPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(CreateEnrolmentWikiPersistenceCommand command)
        {
            await context.EnrolmentWikis.AddAsync(command.EnrolmentWiki);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
