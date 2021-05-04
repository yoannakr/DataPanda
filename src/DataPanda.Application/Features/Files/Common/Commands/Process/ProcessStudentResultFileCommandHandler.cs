using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using DataPanda.Application.Persistence.Courses.Queries.GetByName;
using DataPanda.Application.Persistence.Enrolments.Commands.Create;
using DataPanda.Application.Persistence.Enrolments.Commands.Update;
using DataPanda.Application.Persistence.Enrolments.Queries.GetForStudent;
using DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType;
using DataPanda.Application.Persistence.Students.Commands.Create;
using DataPanda.Application.Persistence.Students.Queries.GetById;
using DataPanda.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Common.Commands.Process
{
    public class ProcessStudentResultFileCommandHandler : ICommandHandler<ProcessFileCommand, Result>
    {
        private readonly IParser<IEnumerable<StudentResult>> studentResultParser;

        private readonly IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result> createEnrolmentPersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<CreateStudentPersistenceCommand, Result> createStudentPersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<UpdateEnrolmentPersistenceCommand, Result> updateEnrolmentPersistenceCommandHandler;

        private readonly IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment> getEnrolmentForStudentPersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student> getStudentByIdPersistenceQueryHandler;

        public ProcessStudentResultFileCommandHandler(
            IParser<IEnumerable<StudentResult>> studentResultParser,

            IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result> createEnrolmentPersistenceCommandHandler,
            IPersistenceCommandHandler<CreateStudentPersistenceCommand, Result> createStudentPersistenceCommandHandler,
            IPersistenceCommandHandler<UpdateEnrolmentPersistenceCommand, Result> updateEnrolmentPersistenceCommandHandler,

            IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler,
            IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler,
            IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment> getEnrolmentForStudentPersistenceQueryHandler,
            IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student> getStudentByIdPersistenceQueryHandler)
        {
            this.studentResultParser = studentResultParser;

            this.createEnrolmentPersistenceCommandHandler = createEnrolmentPersistenceCommandHandler;
            this.createStudentPersistenceCommandHandler = createStudentPersistenceCommandHandler;
            this.updateEnrolmentPersistenceCommandHandler = updateEnrolmentPersistenceCommandHandler;

            this.getCourseByNamePersistenceQueryHandler = getCourseByNamePersistenceQueryHandler;
            this.getLearningPlatformByNameAndTypePersistenceQueryHandler = getLearningPlatformByNameAndTypePersistenceQueryHandler;
            this.getEnrolmentForStudentPersistenceQueryHandler = getEnrolmentForStudentPersistenceQueryHandler;
            this.getStudentByIdPersistenceQueryHandler = getStudentByIdPersistenceQueryHandler;
        }

        public async Task<Result> Handle(ProcessFileCommand command)
        {
            var studentResultParsingResult = await studentResultParser.Parse(command.FileStream);
            if (!studentResultParsingResult.Succeeded)
            {
                return studentResultParsingResult.FailurePayload;
            }

            var course = await getCourseByNamePersistenceQueryHandler.Handle(new GetCourseByNamePersistenceQuery(command.CourseName));
            var learningPlatform = await getLearningPlatformByNameAndTypePersistenceQueryHandler.Handle(new GetLearningPlatformByNameAndTypePersistenceQuery(command.LearningPlatformName, command.LearningPlatformType));

            foreach (var studentResult in studentResultParsingResult.SuccessPayload)
            {
                await CreateStudentIfNotExist(studentResult.Id);
                var createEnrolmentResult = await CreateEnrolmentIfNotExist(course.Id, learningPlatform.Id, studentResult.Id, 0);

                var enrolment = createEnrolmentResult.SuccessPayload;
                enrolment.Grade = studentResult.Result;
                await updateEnrolmentPersistenceCommandHandler.Handle(new UpdateEnrolmentPersistenceCommand(enrolment));
            }

            return Result.Success();
        }

        private async Task<Result> CreateStudentIfNotExist(int studentId)
        {
            var student = await getStudentByIdPersistenceQueryHandler.Handle(new GetStudentByIdPersistenceQuery(studentId));
            if (student is null)
            {
                student = new Student(studentId);
                var createStudentResult = await createStudentPersistenceCommandHandler.Handle(new CreateStudentPersistenceCommand(student));

                if (!createStudentResult.Succeeded)
                {
                    return createStudentResult.FailurePayload;
                }
            }

            return Result.Success();
        }

        private async Task<Result<Enrolment>> CreateEnrolmentIfNotExist(int courseId, int learningPlatformId, int studentId, double studentResult)
        {
            var enrolment = await getEnrolmentForStudentPersistenceQueryHandler.Handle(new GetEnrolmentForStudentPersistenceQuery(studentId, courseId, learningPlatformId));
            if (enrolment is null)
            {
                enrolment = new Enrolment(courseId, learningPlatformId, studentId, studentResult);
                var createEnrolmentResult = await createEnrolmentPersistenceCommandHandler.Handle(new CreateEnrolmentPersistenceCommand(enrolment));

                if (!createEnrolmentResult.Succeeded)
                {
                    return createEnrolmentResult.FailurePayload;
                }
            }

            return enrolment;
        }
    }
}
