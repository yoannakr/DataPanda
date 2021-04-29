using System.Threading.Tasks;

namespace DataPanda.Application.Contracts.CQRS.Commands
{
    public interface IPersistenceCommandHandler<TCommand, TResult>
        where TCommand : IPersistenceCommand
    {
        Task<TResult> Handle(TCommand command);
    }
}
