using System.Threading.Tasks;

namespace DataPanda.Application.Contracts.CQRS.Queries
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}
