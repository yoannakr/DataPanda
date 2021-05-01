using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Courses.Commands.Create
{
    public class CreateCoursePersistenceCommand : IPersistenceCommand<Result>
    {
        public CreateCoursePersistenceCommand(Course course)
        {
            Course = course;
        }

        public Course Course { get; }
    }
}
