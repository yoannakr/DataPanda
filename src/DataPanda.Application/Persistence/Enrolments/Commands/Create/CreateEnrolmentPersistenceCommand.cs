using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Enrolments.Commands.Create
{
    public class CreateEnrolmentPersistenceCommand : IPersistenceCommand<Result>
    {
        public CreateEnrolmentPersistenceCommand(Enrolment enrolment)
        {
            Enrolment = enrolment;
        }

        public Enrolment Enrolment { get; }
    }
}
