using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.EnrolmentAssignments.Commands.Create;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.EnrolmentAssignment.Commands.Create
{
    public class CreateEnrolmentAssignmentPersistenceCommandHandler : IPersistenceCommandHandler<CreateEnrolmentAssignmentPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public CreateEnrolmentAssignmentPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(CreateEnrolmentAssignmentPersistenceCommand command)
        {
            await context.EnrolmentAssignments.AddAsync(command.EnrolmentAssignment);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
