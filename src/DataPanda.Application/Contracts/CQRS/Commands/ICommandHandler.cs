using DataPanda.Application.Contracts.CQRS.Results;
using System.Threading.Tasks;

namespace DataPanda.Application.Contracts.CQRS.Commands
{
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : Result
    {
        Task<TResult> Handle(TCommand command);
    }
}
