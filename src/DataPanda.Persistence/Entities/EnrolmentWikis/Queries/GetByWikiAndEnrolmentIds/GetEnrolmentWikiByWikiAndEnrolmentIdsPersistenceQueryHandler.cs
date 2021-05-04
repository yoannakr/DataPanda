using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.EnrolmentWikis.Queries.GetByWikiAndEnrolmentIds;
using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.EnrolmentWikis.Queries.GetByWikiAndEnrolmentIds
{
    public class GetEnrolmentWikiByWikiAndEnrolmentIdsPersistenceQueryHandler : IPersistenceQueryHandler<GetEnrolmentWikiByWikiAndEnrolmentIdsPersistenceQuery, EnrolmentWiki>
    {
        private readonly DataPandaDbContext context;

        public GetEnrolmentWikiByWikiAndEnrolmentIdsPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<EnrolmentWiki> Handle(GetEnrolmentWikiByWikiAndEnrolmentIdsPersistenceQuery query)
            => await context.EnrolmentWikis.FirstOrDefaultAsync(enrolmentWiki
                => enrolmentWiki.WikiId == query.WikiId && enrolmentWiki.EnrolmentId == query.EnrolmentId);

    }
}
