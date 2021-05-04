using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Students.Queries.GetById;
using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Students.Queries.GetById
{
    public class GetStudentByIdPersistenceQueryHandler : IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student>
    {
        private readonly DataPandaDbContext context;

        public GetStudentByIdPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Student> Handle(GetStudentByIdPersistenceQuery query)
            => await context.Students.FirstOrDefaultAsync(student => student.Id == query.StudentId);
    }
}
