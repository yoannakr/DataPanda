using System.Threading.Tasks;

namespace DataPanda.Application.Contracts.CQRS.Commands
{
    public interface ICommandHandler<TCommand, TResult>
        where TCommand : ICommand
    {
        Task<TResult> Handle(TCommand command);
    }
}
