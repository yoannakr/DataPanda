using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.EnrolmentAssignments.Queries.GetByAssignmentAndEnrolmentIds;
using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.EnrolmentAssignments.Queries.GeByAssignmentAndEnrolmentIds
{
    public class GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQueryHandler : IPersistenceQueryHandler<GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQuery, EnrolmentAssignment>
    {
        private readonly DataPandaDbContext context;

        public GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<EnrolmentAssignment> Handle(GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQuery query)
            => await context.EnrolmentAssignments.FirstOrDefaultAsync(enrolmentAssignment
                => enrolmentAssignment.AssignmentId == query.AssignmentId && enrolmentAssignment.EnrolmentId == query.EnrolmentId);
    }
}
