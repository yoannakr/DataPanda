using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Students.Queries.GetById
{
    public class GetStudentByIdPersistenceQuery : IPersistenceQuery<Student>
    {
        public GetStudentByIdPersistenceQuery(int studentId)
        {
            StudentId = studentId;
        }

        public int StudentId { get; }
    }
}
