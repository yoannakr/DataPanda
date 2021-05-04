using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.EnrolmentAssignments.Queries.GetByAssignmentAndEnrolmentIds
{
    public class GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQuery : IPersistenceQuery<EnrolmentAssignment>
    {
        public GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQuery(int assignmentId, int enrolmentId)
        {
            AssignmentId = assignmentId;
            EnrolmentId = enrolmentId;
        }

        public int AssignmentId { get; }

        public int EnrolmentId { get; }
    }
}
