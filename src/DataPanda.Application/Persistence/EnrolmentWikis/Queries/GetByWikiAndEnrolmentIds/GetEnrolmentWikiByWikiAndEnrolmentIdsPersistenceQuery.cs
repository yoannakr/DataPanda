using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.EnrolmentWikis.Queries.GetByWikiAndEnrolmentIds
{
    public class GetEnrolmentWikiByWikiAndEnrolmentIdsPersistenceQuery : IPersistenceQuery<EnrolmentWiki>
    {
        public GetEnrolmentWikiByWikiAndEnrolmentIdsPersistenceQuery(int wikiId, int enrolmentId)
        {
            WikiId = wikiId;
            EnrolmentId = enrolmentId;
        }

        public int WikiId { get; }

        public int EnrolmentId { get; }
    }
}
