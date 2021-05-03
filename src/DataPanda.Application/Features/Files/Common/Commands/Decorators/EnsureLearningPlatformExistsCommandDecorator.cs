using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.LearningPlatforms.Commands.Create;
using DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType;
using DataPanda.Domain.Entities;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Common.Commands.Decorators
{
    public class EnsureLearningPlatformExistsCommandDecorator<TCommand> : ICommandHandler<TCommand, Result>
        where TCommand : FileCommand
    {
        private readonly ICommandHandler<TCommand, Result> decoratedCommandHandler;
        private readonly IPersistenceCommandHandler<CreateLearningPlatformPersistenceCommand, Result> createLearningPlatformPersistenceCommandHandler;
        private readonly IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler;

        public EnsureLearningPlatformExistsCommandDecorator(
            ICommandHandler<TCommand, Result> decoratedCommandHandler,
            IPersistenceCommandHandler<CreateLearningPlatformPersistenceCommand, Result> createLearningPlatformPersistenceCommandHandler,
            IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler)
        {
            this.decoratedCommandHandler = decoratedCommandHandler;
            this.createLearningPlatformPersistenceCommandHandler = createLearningPlatformPersistenceCommandHandler;
            this.getLearningPlatformByNameAndTypePersistenceQueryHandler = getLearningPlatformByNameAndTypePersistenceQueryHandler;
        }

        public async Task<Result> Handle(TCommand command)
        {
            var learningPlatform = await getLearningPlatformByNameAndTypePersistenceQueryHandler.Handle(new GetLearningPlatformByNameAndTypePersistenceQuery(command.PlatformName, command.PlatformType));
            if (learningPlatform is not null)
            {
                return await decoratedCommandHandler.Handle(command);
            }

            learningPlatform = new LearningPlatform(command.PlatformName, command.PlatformType, command.PlatformUrl);

            var createLearningPlatformResult = await createLearningPlatformPersistenceCommandHandler.Handle(new CreateLearningPlatformPersistenceCommand(learningPlatform));
            if (!createLearningPlatformResult.Succeeded)
            {
                return createLearningPlatformResult.FailurePayload;
            }

            return await decoratedCommandHandler.Handle(command);
        }
    }
}
