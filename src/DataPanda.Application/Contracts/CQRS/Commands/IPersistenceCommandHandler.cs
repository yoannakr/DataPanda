using DataPanda.Application.Contracts.CQRS.Results;
using System.Threading.Tasks;

namespace DataPanda.Application.Contracts.CQRS.Commands
{
    public interface IPersistenceCommandHandler<TCommand, TResult>
        where TCommand : IPersistenceCommand<TResult>
        where TResult : Result
    {
        Task<TResult> Handle(TCommand command);
    }
}
