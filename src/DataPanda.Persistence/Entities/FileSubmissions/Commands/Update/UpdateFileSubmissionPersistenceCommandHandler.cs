using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.FileSubmissions.Commands.Update;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.FileSubmissions.Commands.Update
{
    public class UpdateFileSubmissionPersistenceCommandHandler : IPersistenceCommandHandler<UpdateFileSubmissionPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public UpdateFileSubmissionPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(UpdateFileSubmissionPersistenceCommand command)
        {
            context.FileSubmissions.Update(command.FileSubmission);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
