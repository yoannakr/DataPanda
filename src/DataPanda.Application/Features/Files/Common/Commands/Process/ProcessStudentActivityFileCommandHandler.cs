using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using DataPanda.Application.Persistence.Assignments.Commands.Create;
using DataPanda.Application.Persistence.Assignments.Queries.GetById;
using DataPanda.Application.Persistence.Courses.Queries.GetByName;
using DataPanda.Application.Persistence.EnrolmentAssignments.Commands.Create;
using DataPanda.Application.Persistence.EnrolmentAssignments.Queries.GetByAssignmentAndEnrolmentIds;
using DataPanda.Application.Persistence.Enrolments.Commands.Create;
using DataPanda.Application.Persistence.Enrolments.Queries.GetForStudent;
using DataPanda.Application.Persistence.EnrolmentWikis.Commands.Create;
using DataPanda.Application.Persistence.FileSubmissions.Commands.Create;
using DataPanda.Application.Persistence.LearningPlatforms.Queries.GetByNameAndType;
using DataPanda.Application.Persistence.Students.Commands.Create;
using DataPanda.Application.Persistence.Students.Queries.GetById;
using DataPanda.Application.Persistence.Wikis.Commands.Create;
using DataPanda.Domain.Entities;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Common.Commands.Process
{
    public class ProcessStudentActivityFileCommandHandler : ICommandHandler<ProcessFileCommand, Result>
    {
        private readonly IParser<IEnumerable<StudentActivity>> studentActivityParser;

        private readonly IPersistenceCommandHandler<CreateStudentPersistenceCommand, Result> createStudentPersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result> createEnrolmentPersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<CreateAssignmentPersistenceCommand, Result> createAssignmentPersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<CreateEnrolmentAssignmentPersistenceCommand, Result> createEnrolmentAssignmentPersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<CreateFileSubmissionPersistenceCommand, Result> createFileSubmissionPersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<CreateWikiPersistenceCommand, Result> createWikiPersistenceCommandHandler;
        private readonly IPersistenceCommandHandler<CreateEnrolmentWikiPersistenceCommand, Result> createEnrolmentWikiPersistenceCommandHandler;

        private readonly IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment> getEnrolmentForStudentPersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student> getStudentByIdPersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetAssignmentByIdPersistenceQuery, Assignment> getAssignmentByIdPersistenceQueryHandler;
        private readonly IPersistenceQueryHandler<GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQuery, EnrolmentAssignment> getEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQueryHandler;

        public ProcessStudentActivityFileCommandHandler(
            IParser<IEnumerable<StudentActivity>> studentActivityParser,

            IPersistenceCommandHandler<CreateStudentPersistenceCommand, Result> createStudentPersistenceCommandHandler,
            IPersistenceCommandHandler<CreateEnrolmentPersistenceCommand, Result> createEnrolmentPersistenceCommandHandler,
            IPersistenceCommandHandler<CreateAssignmentPersistenceCommand, Result> createAssignmentPersistenceCommandHandler,
            IPersistenceCommandHandler<CreateEnrolmentAssignmentPersistenceCommand, Result> createEnrolmentAssignmentPersistenceCommandHandler,
            IPersistenceCommandHandler<CreateFileSubmissionPersistenceCommand, Result> createFileSubmissionPersistenceCommandHandler,
            IPersistenceCommandHandler<CreateWikiPersistenceCommand, Result> createWikiPersistenceCommandHandler,
            IPersistenceCommandHandler<CreateEnrolmentWikiPersistenceCommand, Result> createEnrolmentWikiPersistenceCommandHandler,

            IPersistenceQueryHandler<GetCourseByNamePersistenceQuery, Course> getCourseByNamePersistenceQueryHandler,
            IPersistenceQueryHandler<GetLearningPlatformByNameAndTypePersistenceQuery, LearningPlatform> getLearningPlatformByNameAndTypePersistenceQueryHandler,
            IPersistenceQueryHandler<GetEnrolmentForStudentPersistenceQuery, Enrolment> getEnrolmentForStudentPersistenceQueryHandler,
            IPersistenceQueryHandler<GetStudentByIdPersistenceQuery, Student> getStudentByIdPersistenceQueryHandler,
            IPersistenceQueryHandler<GetAssignmentByIdPersistenceQuery, Assignment> getAssignmentByIdPersistenceQueryHandler,
            IPersistenceQueryHandler<GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQuery, EnrolmentAssignment> getEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQueryHandler)
        {
            this.studentActivityParser = studentActivityParser;

            this.createStudentPersistenceCommandHandler = createStudentPersistenceCommandHandler;
            this.createEnrolmentPersistenceCommandHandler = createEnrolmentPersistenceCommandHandler;
            this.createAssignmentPersistenceCommandHandler = createAssignmentPersistenceCommandHandler;
            this.createEnrolmentAssignmentPersistenceCommandHandler = createEnrolmentAssignmentPersistenceCommandHandler;
            this.createFileSubmissionPersistenceCommandHandler = createFileSubmissionPersistenceCommandHandler;
            this.createWikiPersistenceCommandHandler = createWikiPersistenceCommandHandler;
            this.createEnrolmentWikiPersistenceCommandHandler = createEnrolmentWikiPersistenceCommandHandler;

            this.getCourseByNamePersistenceQueryHandler = getCourseByNamePersistenceQueryHandler;
            this.getLearningPlatformByNameAndTypePersistenceQueryHandler = getLearningPlatformByNameAndTypePersistenceQueryHandler;
            this.getEnrolmentForStudentPersistenceQueryHandler = getEnrolmentForStudentPersistenceQueryHandler;
            this.getStudentByIdPersistenceQueryHandler = getStudentByIdPersistenceQueryHandler;
            this.getAssignmentByIdPersistenceQueryHandler = getAssignmentByIdPersistenceQueryHandler;
            this.getEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQueryHandler = getEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQueryHandler;
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
                    var fileSubmissionId = int.Parse(matches[1].Value);
                    var assignmentId = int.Parse(matches[2].Value);

                    var createStudentResult = await CreateStudentIfNotExist(studentId);
                    var createEnrolmentResult = await CreateEnrolmentIfNotExist(course.Id, learningPlatform.Id, studentId, 0);
                    var createAssignmentResult = await CreateAssignmenIfNotExist(assignmentId);
                    var createEnrolmentAssignmentResult = await CreateEnrolmentAssignmenIfNotExist(assignmentId, createEnrolmentResult.SuccessPayload.Id);


                    var fileSubmission = new FileSubmission(fileSubmissionId, createEnrolmentAssignmentResult.SuccessPayload.Id, 0);
                    await createFileSubmissionPersistenceCommandHandler.Handle(new CreateFileSubmissionPersistenceCommand(fileSubmission));
                }
                else if (studentActivity.Component == "Wiki" && studentActivity.EventName == "Wiki page updated")
                {
                    var matches = Regex.Matches(studentActivity.Description, @"(?<=')\d+(?=')");

                    var studentId = int.Parse(matches[0].Value);
                    var wikiId = int.Parse(matches[1].Value);
                    var wikiName = studentActivity.EventContext.Substring(6);

                    var createStudentResult = await CreateStudentIfNotExist(studentId);
                    var createEnrolmentResult = await CreateEnrolmentIfNotExist(course.Id, learningPlatform.Id, studentId, 0);

                    var wiki = new Wiki(wikiId, wikiName);
                    await createWikiPersistenceCommandHandler.Handle(new CreateWikiPersistenceCommand(wiki));

                    var enrolmentWiki = new EnrolmentWiki(wiki.Id, createEnrolmentResult.SuccessPayload.Id, 1);
                    await createEnrolmentWikiPersistenceCommandHandler.Handle(new CreateEnrolmentWikiPersistenceCommand(enrolmentWiki));
                }
            }

            return Result.Success();
        }

        private async Task<Result<Student>> CreateStudentIfNotExist(int studentId)
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

            return student;
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

        private async Task<Result<Assignment>> CreateAssignmenIfNotExist(int assignmentId)
        {
            var assignment = await getAssignmentByIdPersistenceQueryHandler.Handle(new GetAssignmentByIdPersistenceQuery(assignmentId));
            if (assignment is null)
            {
                assignment = new Assignment(assignmentId, "Качване на курсови задачи и проекти");
                var createAssignmentResult = await createAssignmentPersistenceCommandHandler.Handle(new CreateAssignmentPersistenceCommand(assignment));

                if (!createAssignmentResult.Succeeded)
                {
                    return createAssignmentResult.FailurePayload;
                }
            }

            return assignment;
        }

        private async Task<Result<EnrolmentAssignment>> CreateEnrolmentAssignmenIfNotExist(int assignmentId, int enrolmentId)
        {
            var enrolmentAssignment = await getEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQueryHandler.Handle(new GetEnrolmentAssignmentByAssignmentAndEnrolmentIdsPersistenceQuery(assignmentId, enrolmentId));
            if (enrolmentAssignment is null)
            {
                enrolmentAssignment = new EnrolmentAssignment(assignmentId, enrolmentId);
                var createEnrolmentAssignmentResult = await createEnrolmentAssignmentPersistenceCommandHandler.Handle(new CreateEnrolmentAssignmentPersistenceCommand(enrolmentAssignment));

                if (!createEnrolmentAssignmentResult.Succeeded)
                {
                    return createEnrolmentAssignmentResult.FailurePayload;
                }
            }

            return enrolmentAssignment;
        }
    }
}
