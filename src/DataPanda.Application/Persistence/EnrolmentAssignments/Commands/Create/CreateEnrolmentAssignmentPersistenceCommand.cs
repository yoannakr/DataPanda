using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.EnrolmentAssignments.Commands.Create
{
    public class CreateEnrolmentAssignmentPersistenceCommand : IPersistenceCommand<Result>
    {
        public CreateEnrolmentAssignmentPersistenceCommand(EnrolmentAssignment enrolmentAssignment)
        {
            EnrolmentAssignment = enrolmentAssignment;
        }

        public EnrolmentAssignment EnrolmentAssignment { get; }
    }
}
