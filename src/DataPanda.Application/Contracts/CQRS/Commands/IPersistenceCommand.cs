using DataPanda.Application.Contracts.CQRS.Results;

namespace DataPanda.Application.Contracts.CQRS.Commands
{
    public interface IPersistenceCommand<TResult>
        where TResult : Result
    {
    }
}
