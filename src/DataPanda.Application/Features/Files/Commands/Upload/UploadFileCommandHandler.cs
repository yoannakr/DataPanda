using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using DataPanda.Application.Persistence.Courses.Commands.Create;
using DataPanda.Application.Persistence.Courses.Queries.GetByName;
using DataPanda.Application.Persistence.LearningPlatforms.Commands.Create;
using DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType;
using DataPanda.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Commands.Upload
{
    public class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, Result>
    {
        private readonly IParser<IEnumerable<StudentResult>> studentResultParser;

        private readonly IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result> createCoursePersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<CreateLearningPlatformPersistenceCommand, Result> createLearningPlatformPersistenceCommandHandler;

        private readonly IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler;

        public UploadFileCommandHandler(
            IParser<IEnumerable<StudentResult>> studentResultParser,
            IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result> createCoursePersistenceCommandHandler,
            IPersistenceCommandHandler<CreateLearningPlatformPersistenceCommand, Result> createLearningPlatformPersistenceCommandHandler,
            IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler,
            IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler)
        {
            this.studentResultParser = studentResultParser;
            this.createCoursePersistenceCommandHandler = createCoursePersistenceCommandHandler;
            this.createLearningPlatformPersistenceCommandHandler = createLearningPlatformPersistenceCommandHandler;
            this.getCourseByNamePersistenceQueryHandler = getCourseByNamePersistenceQueryHandler;
            this.getLearningPlatformByNameAndTypePersistenceQueryHandler = getLearningPlatformByNameAndTypePersistenceQueryHandler;
        }

        public async Task<Result> Handle(UploadFileCommand command)
        {
            var course = await getCourseByNamePersistenceQueryHandler.Handle(new GetCourseByNamePersistenceQuery(command.CourseName));
            if (course == null)
            {
                course = new Course(command.CourseName, command.CourseFieldOfApplication);
                var createCourseResult = await createCoursePersistenceCommandHandler.Handle(new CreateCoursePersistenceCommand(course));

                if (!createCourseResult.Succeeded)
                {
                    return createCourseResult.FailurePayload;
                }
            }

            var learningPlatform = await getLearningPlatformByNameAndTypePersistenceQueryHandler.Handle(new GetLearningPlatformByNameAndTypePersistenceQuery(command.PlatformName, command.PlatformType));
            if (learningPlatform == null)
            {
                learningPlatform = new LearningPlatform(command.PlatformName, command.PlatformType, command.PlatformUrl);
                var createLearningPlatformResult = await createLearningPlatformPersistenceCommandHandler.Handle(new CreateLearningPlatformPersistenceCommand(learningPlatform));

                if (!createLearningPlatformResult.Succeeded)
                {
                    return createLearningPlatformResult.FailurePayload;
                }
            }

            var result = await studentResultParser.Parse(command.FileStream);
            foreach (var studentResult in result.SuccessPayload)
            {
            }

            return Result.Success();
        }
    }
}
