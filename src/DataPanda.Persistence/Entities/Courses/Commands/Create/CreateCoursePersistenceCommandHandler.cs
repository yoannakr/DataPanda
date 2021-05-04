using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Courses.Commands.Create;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Courses.Commands.Create
{
    public class CreateCoursePersistenceCommandHandler : IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result>
    {
        private readonly DataPandaDbContext context;

        public CreateCoursePersistenceCommandHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Result> Handle(CreateCoursePersistenceCommand command)
        {
            await context.Courses.AddAsync(command.Course);
            await context.SaveChangesAsync();

            return Result.Success();
        }
    }
}
