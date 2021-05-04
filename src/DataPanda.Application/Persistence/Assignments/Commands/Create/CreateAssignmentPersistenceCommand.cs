using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Assignments.Commands.Create
{
    public class CreateAssignmentPersistenceCommand : IPersistenceCommand<Result>
    {
        public CreateAssignmentPersistenceCommand(Assignment assignment)
        {
            Assignment = assignment;
        }

        public Assignment Assignment { get; }
    }
}
