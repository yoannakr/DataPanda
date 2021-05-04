using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.EnrolmentWikis.Commands.Create
{
    public class CreateEnrolmentWikiPersistenceCommand : IPersistenceCommand<Result>
    {
        public CreateEnrolmentWikiPersistenceCommand(EnrolmentWiki enrolmentWiki)
        {
            EnrolmentWiki = enrolmentWiki;
        }

        public EnrolmentWiki EnrolmentWiki { get; }
    }
}
