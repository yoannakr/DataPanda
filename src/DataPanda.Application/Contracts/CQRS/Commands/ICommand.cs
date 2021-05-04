using DataPanda.Application.Contracts.CQRS.Results;

namespace DataPanda.Application.Contracts.CQRS.Commands
{
    public interface ICommand<TResult>
        where TResult : Result
    {
    }
}
