using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Courses.Queries.GetByName
{
    public class GetCourseByNamePersistenceQuery : IPersistenceQuery<Course>
    {
        public GetCourseByNamePersistenceQuery(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
