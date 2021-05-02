using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Students.Commands.Create;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Students.Commands.Create
{
    public class CreateStudentPersistenceCommandHandler : IPersistenceCommandHandler<CreateStudentPersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public CreateStudentPersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(CreateStudentPersistenceCommand command)
        {
            await context.Students.AddAsync(command.Student);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
