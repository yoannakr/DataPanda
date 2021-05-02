using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using DataPanda.Application.Persistence.Courses.Commands.Create;
using DataPanda.Application.Persistence.Courses.Queries.GetByName;
using DataPanda.Application.Persistence.Enrolments.Commands.Create;
using DataPanda.Application.Persistence.Enrolments.Queries.GetForStudent;
using DataPanda.Application.Persistence.LearningPlatforms.Commands.Create;
using DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType;
using DataPanda.Application.Persistence.Students.Commands.Create;
using DataPanda.Application.Persistence.Students.Queries.GetById;
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
        private readonly IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result> createEnrolmentPersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<CreateStudentPersistenceCommand, Result> createStudentPersistenceCommandHandler;

        private readonly IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment> getEnrolmentForStudentPersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student> getStudentByIdPersistenceQueryHandler;

        public UploadFileCommandHandler(
            IParser<IEnumerable<StudentResult>> studentResultParser,
            IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result> createCoursePersistenceCommandHandler,
            IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler,
            IPersistenceCommandHandler<CreateLearningPlatformPersistenceCommand, Result> createLearningPlatformPersistenceCommandHandler,
            IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler,
            IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result> createEnrolmentPersistenceCommandHandler,
            IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment> getEnrolmentForStudentPersistenceQueryHandler,
            IPersistenceCommandHandler<CreateStudentPersistenceCommand, Result> createStudentPersistenceCommandHandler,
            IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student> getStudentByIdPersistenceQueryHandler)
        {
            this.studentResultParser = studentResultParser;

            this.createCoursePersistenceCommandHandler = createCoursePersistenceCommandHandler;
            this.getCourseByNamePersistenceQueryHandler = getCourseByNamePersistenceQueryHandler;

            this.createLearningPlatformPersistenceCommandHandler = createLearningPlatformPersistenceCommandHandler;
            this.getLearningPlatformByNameAndTypePersistenceQueryHandler = getLearningPlatformByNameAndTypePersistenceQueryHandler;

            this.createEnrolmentPersistenceCommandHandler = createEnrolmentPersistenceCommandHandler;
            this.getEnrolmentForStudentPersistenceQueryHandler = getEnrolmentForStudentPersistenceQueryHandler;

            this.createStudentPersistenceCommandHandler = createStudentPersistenceCommandHandler;
            this.getStudentByIdPersistenceQueryHandler = getStudentByIdPersistenceQueryHandler;
        }

        public async Task<Result> Handle(UploadFileCommand command)
        {
            var course = await getCourseByNamePersistenceQueryHandler.Handle(new GetCourseByNamePersistenceQuery(command.CourseName));
            if (course is null)
            {
                course = new Course(command.CourseName, command.CourseFieldOfApplication);
                var createCourseResult = await createCoursePersistenceCommandHandler.Handle(new CreateCoursePersistenceCommand(course));

                if (!createCourseResult.Succeeded)
                {
                    return createCourseResult.FailurePayload;
                }
            }

            var learningPlatform = await getLearningPlatformByNameAndTypePersistenceQueryHandler.Handle(new GetLearningPlatformByNameAndTypePersistenceQuery(command.PlatformName, command.PlatformType));
            if (learningPlatform is null)
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
                var student = await getStudentByIdPersistenceQueryHandler.Handle(new GetStudentByIdPersistenceQuery(studentResult.Id));
                if (student is null)
                {
                    student = new Student(studentResult.Id);
                    var createStudentResult = await createStudentPersistenceCommandHandler.Handle(new CreateStudentPersistenceCommand(student));

                    if (!createStudentResult.Succeeded)
                    {
                        return createStudentResult.FailurePayload;
                    }
                }

                var enrolment = await getEnrolmentForStudentPersistenceQueryHandler.Handle(new GetEnrolmentForStudentPersistenceQuery(studentResult.Id, course.Id, learningPlatform.Id));
                if (enrolment is null)
                {
                    enrolment = new Enrolment(course.Id, learningPlatform.Id, studentResult.Id, studentResult.Result);
                    var createEnrolmentResult = await createEnrolmentPersistenceCommandHandler.Handle(new CreateEnrolmentPersistenceCommand(enrolment));

                    if (!createEnrolmentResult.Succeeded)
                    {
                        return createEnrolmentResult.FailurePayload;
                    }
                }
            }

            return Result.Success();
        }
    }
}
