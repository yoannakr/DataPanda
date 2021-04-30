using System.Threading.Tasks;

namespace DataPanda.Application.Contracts.CQRS.Queries
{
    public interface IPersistenceQueryHandler<TQuery, TResult>
        where TQuery : IPersistenceQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
