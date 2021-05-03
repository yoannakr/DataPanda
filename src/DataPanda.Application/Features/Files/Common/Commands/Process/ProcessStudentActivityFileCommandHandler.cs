using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using DataPanda.Application.Persistence.Courses.Queries.GetByName;
using DataPanda.Application.Persistence.Enrolments.Queries.GetForStudent;
using DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType;
using DataPanda.Application.Persistence.Students.Queries.GetById;
using DataPanda.Domain.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Common.Commands.Process
{
    public class ProcessStudentActivityFileCommandHandler : ICommandHandler<ProcessFileCommand, Result>
    {
        private readonly IParser<IEnumerable<StudentActivity>> studentActivityParser;

        private readonly IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment> getEnrolmentForStudentPersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student> getStudentByIdPersistenceQueryHandler;

        public ProcessStudentActivityFileCommandHandler(
            IParser<IEnumerable<StudentActivity>> studentActivityParser,

            IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler,
            IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler,
            IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment> getEnrolmentForStudentPersistenceQueryHandler,
            IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student> getStudentByIdPersistenceQueryHandler)
        {
            this.studentActivityParser = studentActivityParser;

            this.getCourseByNamePersistenceQueryHandler = getCourseByNamePersistenceQueryHandler;
            this.getLearningPlatformByNameAndTypePersistenceQueryHandler = getLearningPlatformByNameAndTypePersistenceQueryHandler;
            this.getEnrolmentForStudentPersistenceQueryHandler = getEnrolmentForStudentPersistenceQueryHandler;
            this.getStudentByIdPersistenceQueryHandler = getStudentByIdPersistenceQueryHandler;
        }

        public async Task<Result> Handle(ProcessFileCommand command)
        {
            var studentActivityParsingResult = await studentActivityParser.Parse(command.FileStream);
            if (!studentActivityParsingResult.Succeeded)
            {
                return studentActivityParsingResult.FailurePayload;
            }

            var course = await getCourseByNamePersistenceQueryHandler.Handle(new GetCourseByNamePersistenceQuery(command.CourseName));
            var learningPlatform = await getLearningPlatformByNameAndTypePersistenceQueryHandler.Handle(new GetLearningPlatformByNameAndTypePersistenceQuery(command.LearningPlatformName, command.LearningPlatformType));

            foreach (var studentActivity in studentActivityParsingResult.SuccessPayload)
            {
                if (studentActivity.Component == "File submissions" &&
                    studentActivity.EventContext == "Assignment: Качване на курсови задачи и проекти" &&
                    studentActivity.EventName == "A file has been uploaded.")
                {
                    var matches = Regex.Matches(studentActivity.Description, @"(?<=')\d+(?=')");

                    var studentId = int.Parse(matches[0].Value);

                    var enrolment = await getEnrolmentForStudentPersistenceQueryHandler.Handle(new GetEnrolmentForStudentPersistenceQuery(studentId, course.Id, learningPlatform.Id));
                }
                else if (studentActivity.Component == "Wiki" && studentActivity.EventName == "Wiki page updated")
                {

                }
            }

            throw new System.NotImplementedException();
        }
    }
}
