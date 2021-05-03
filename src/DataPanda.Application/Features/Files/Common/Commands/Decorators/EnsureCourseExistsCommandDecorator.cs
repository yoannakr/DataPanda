using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Persistence.Courses.Commands.Create;
using DataPanda.Application.Persistence.Courses.Queries.GetByName;
using DataPanda.Domain.Entities;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Common.Commands.Decorators
{
    public class EnsureCourseExistsCommandDecorator<TCommand> : ICommandHandler<TCommand, Result>
        where TCommand : FileCommand
    {
        private readonly ICommandHandler<TCommand, Result> decoratedCommandHandler;
        private readonly IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result> createCoursePersistenceCommandHandler;
        private readonly IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler;

        public EnsureCourseExistsCommandDecorator(
            ICommandHandler<TCommand, Result> decoratedCommandHandler,
            IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result> createCoursePersistenceCommandHandler,
            IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler)
        {
            this.decoratedCommandHandler = decoratedCommandHandler;
            this.createCoursePersistenceCommandHandler = createCoursePersistenceCommandHandler;
            this.getCourseByNamePersistenceQueryHandler = getCourseByNamePersistenceQueryHandler;
        }

        public async Task<Result> Handle(TCommand command)
        {
            var course = await getCourseByNamePersistenceQueryHandler.Handle(new GetCourseByNamePersistenceQuery(command.CourseName));
            if (course is not null)
            {
                return await decoratedCommandHandler.Handle(command);
            }

            course = new Course(command.CourseName, command.CourseFieldOfApplication);

            var createCourseResult = await createCoursePersistenceCommandHandler.Handle(new CreateCoursePersistenceCommand(course));
            if (!createCourseResult.Succeeded)
            {
                return createCourseResult.FailurePayload;
            }

            return await decoratedCommandHandler.Handle(command);
        }
    }
}
