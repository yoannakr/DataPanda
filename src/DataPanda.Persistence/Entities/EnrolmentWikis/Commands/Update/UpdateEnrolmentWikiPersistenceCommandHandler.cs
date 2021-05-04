using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.EnrolmentWikis.Commands.Update;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.EnrolmentWikis.Commands.Update
{
    public class UpdateEnrolmentWikiPersistenceCommandHandler : IPersistenceCommandHandler<UpdateEnrolmentWikiPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public UpdateEnrolmentWikiPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(UpdateEnrolmentWikiPersistenceCommand command)
        {
            context.EnrolmentWikis.Update(command.EnrolmentWiki);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
