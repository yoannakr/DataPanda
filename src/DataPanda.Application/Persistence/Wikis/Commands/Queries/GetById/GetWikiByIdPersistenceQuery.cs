using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Wikis.Commands.Queries.GetById
{
    public class GetWikiByIdPersistenceQuery : IPersistenceQuery<Wiki>
    {
        public GetWikiByIdPersistenceQuery(int wikiId)
        {
            WikiId = wikiId;
        }

        public int WikiId { get; }
    }
}
