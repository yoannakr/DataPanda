using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Enrolments.Commands.Create;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Enrolments.Commands.Create
{
    public class CreateEnrolmentPersistenceCommandHandler : IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public CreateEnrolmentPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(CreateEnrolmentPersistenceCommand command)
        {
            await context.Enrolments.AddAsync(command.Enrolment);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
