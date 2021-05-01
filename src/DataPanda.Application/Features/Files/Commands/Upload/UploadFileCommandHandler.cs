﻿using DataPanda.Application.Contracts.CQRS.Commands;
using DataPanda.Application.Contracts.CQRS.Results;
using DataPanda.Application.Contracts.Parsers;
using DataPanda.Application.Features.Files.Models;
using DataPanda.Application.Persistence.Courses.Commands.Create;
using DataPanda.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Files.Commands.Upload
{
    public class UploadFileCommandHandler : ICommandHandler<UploadFileCommand, Result>
    {
        private readonly IParser<IEnumerable<StudentResult>> studentResultParser;
        private readonly IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result> createCoursePersistenceCommandHandler;

        public UploadFileCommandHandler(
            IParser<IEnumerable<StudentResult>> studentResultParser,
            IPersistenceCommandHandler<CreateCoursePersistenceCommand, Result> createCoursePersistenceCommandHandler)
        {
            this.studentResultParser = studentResultParser;
            this.createCoursePersistenceCommandHandler = createCoursePersistenceCommandHandler;
        }

        public async Task<Result> Handle(UploadFileCommand command)
        {
            var result = await studentResultParser.Parse(command.FileStream);

            var course = new Course(command.CourseName, command.CourseFieldOfApplication);
            var res = await createCoursePersistenceCommandHandler.Handle(new CreateCoursePersistenceCommand(course));

            var learningPlatform = new LearningPlatform(command.PlatformName, command.PlatformType, command.PlatformUrl);

            foreach (var studentResult in result.SuccessPayload)
            {
                var enrolment = new Enrolment(course.Id, learningPlatform.Id);
            }

            return Result.Success();
        }
    }
}
