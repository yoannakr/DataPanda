using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.FileSubmissions.Commands.Create;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.FileSubmissions.Commands.Create
{
    public class CreateFileSubmissionPersistenceCommandHandler : IPersistenceCommandHandler<CreateFileSubmissionPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public CreateFileSubmissionPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(CreateFileSubmissionPersistenceCommand command)
        {
            await context.FileSubmissions.AddAsync(command.FileSubmission);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
