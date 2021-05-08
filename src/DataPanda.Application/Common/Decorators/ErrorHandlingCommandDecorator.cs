using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using System;
using System.Threading.Tasks;

namespace DataPanda.Application.Common.Decorators
{
    public class ErrorHandlingCommandDecorator<TCommand, TResult> : ICommandHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : Result
    {
        private readonly ICommandHandler<TCommand, TResult> decoratedCommandHandler;

        public ErrorHandlingCommandDecorator(ICommandHandler<TCommand, TResult> decoratedCommandHandler)
        {
            this.decoratedCommandHandler = decoratedCommandHandler;
        }

        public async Task<TResult> Handle(TCommand command)
        {
            try
            {
                return await decoratedCommandHandler.Handle(command);
            }
            catch (Exception)
            {
                return Result.Failure("An error has occured") as TResult;
            }
        }
    }
}
