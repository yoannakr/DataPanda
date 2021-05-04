using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Persistence.Wikis.Commands.Queries.GetById;
using DataPanda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Entities.Wikis.Queries.GetById
{
    public class GetWikiByIdPersistenceQueryHandler : IPersistenceQueryHandler<GetWikiByIdPersistenceQuery, Wiki>
    {
        private readonly DataPandaDbContext context;

        public GetWikiByIdPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<Wiki> Handle(GetWikiByIdPersistenceQuery query)
            => await context.Wikis.FirstOrDefaultAsync(wiki => wiki.Id == query.WikiId);
    }
}
