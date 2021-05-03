using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Assignments.Commands.Create;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Assignments.Commands.Create
{
    public class CreateAssignmentPersistenceCommandHandler : IPersistenceCommandHandler<CreateAssignmentPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public CreateAssignmentPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(CreateAssignmentPersistenceCommand command)
        {
            await context.Assignments.AddAsync(command.Assignment);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
