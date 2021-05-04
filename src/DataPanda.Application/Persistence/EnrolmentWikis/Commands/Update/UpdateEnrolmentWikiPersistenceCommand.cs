using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.EnrolmentWikis.Commands.Update
{
    public class UpdateEnrolmentWikiPersistenceCommand : IPersistenceCommand<Result>
    {
        public UpdateEnrolmentWikiPersistenceCommand(EnrolmentWiki enrolmentWiki)
        {
            EnrolmentWiki = enrolmentWiki;
        }

        public EnrolmentWiki EnrolmentWiki { get; }
    }
}
