using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Enrolments.Commands.Update
{
    public class UpdateEnrolmentPersistenceCommand : IPersistenceCommand<Result>
    {
        public UpdateEnrolmentPersistenceCommand(Enrolment enrolment)
        {
            Enrolment = enrolment;
        }

        public Enrolment Enrolment { get; }
    }
}
