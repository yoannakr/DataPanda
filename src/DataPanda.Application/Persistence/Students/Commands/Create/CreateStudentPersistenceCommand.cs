using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Students.Commands.Create
{
    public class CreateStudentPersistenceCommand : IPersistenceCommand<Result>
    {
        public CreateStudentPersistenceCommand(Student student)
        {
            Student = student;
        }

        public Student Student { get; }
    }
}
