using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Domain.Entities;

namespace DataPanda.Application.Persistence.Wikis.Commands.Create
{
    public class CreateWikiPersistenceCommand : IPersistenceCommand<Result>
    {
        public CreateWikiPersistenceCommand(Wiki wiki)
        {
            Wiki = wiki;
        }

        public Wiki Wiki { get; }
    }
}
