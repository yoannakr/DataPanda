using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Enrolments.Commands.Update;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Enrolments.Commands.Update
{
    public class UpdateEnrolmentPersistenceCommandHandler : IPersistenceCommandHandler<UpdateEnrolmentPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public UpdateEnrolmentPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(UpdateEnrolmentPersistenceCommand command)
        {
            context.Enrolments.Update(command.Enrolment);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
