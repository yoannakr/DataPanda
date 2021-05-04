using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Assignments.Queries.GetById;
using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Assignments.Queries.GetById
{
    public class GetAssignmentByIdPersistenceQueryHandler : IPersistenceQueryHandler<GetAssignmentByIdPersistenceQuery, Assignment>
    {
        private readonly DataPandaDbContext context;

        public GetAssignmentByIdPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Assignment> Handle(GetAssignmentByIdPersistenceQuery query)
            => await context.Assignments.FirstOrDefaultAsync(assignment => assignment.Id == query.Id);
    }
}
