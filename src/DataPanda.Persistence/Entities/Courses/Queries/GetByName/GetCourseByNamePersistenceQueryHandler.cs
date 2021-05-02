using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Courses.Queries.GetByName;
using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Courses.Queries.GetByName
{
    public class GetCourseByNamePersistenceQueryHandler : IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course>
    {
        private readonly DataPandaDbContext context;

        public GetCourseByNamePersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Course> Handle(GetCourseByNamePersistenceQuery query)
            => await context.Courses.FirstOrDefaultAsync(course => course.Name == query.Name);
    }
}
