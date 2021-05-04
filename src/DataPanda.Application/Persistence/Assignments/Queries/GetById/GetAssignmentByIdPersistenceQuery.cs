using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Assignments.Queries.GetById
{
    public class GetAssignmentByIdPersistenceQuery : IPersistenceQuery<Assignment>
    {
        public GetAssignmentByIdPersistenceQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
