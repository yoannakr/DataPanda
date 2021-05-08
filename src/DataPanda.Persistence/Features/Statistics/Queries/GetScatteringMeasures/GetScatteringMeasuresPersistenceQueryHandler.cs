﻿using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetScatteringMeasures;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Features.Statistics.Queries.GetScatteringMeasures
{
    public class GetScatteringMeasuresPersistenceQueryHandler : IPersistenceQueryHandler<GetScatteringMeasuresPersistenceQuery, ScatteringMeasuresOutputModel>
    {
        private readonly DataPandaDbContext context;

        public GetScatteringMeasuresPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<ScatteringMeasuresOutputModel> Handle(GetScatteringMeasuresPersistenceQuery query)
        {
            var fileSubmissions = await context.FileSubmissions
                .Include(fileSubmission => fileSubmission.EnrolmentAssignment)
                    .ThenInclude(enrolmentAssignment => enrolmentAssignment.Enrolment)
                        .ThenInclude(enrolment => enrolment.Course)
                .Include(fileSubmission => fileSubmission.EnrolmentAssignment)
                    .ThenInclude(enrolmentAssignment => enrolmentAssignment.Enrolment)
                        .ThenInclude(enrolment => enrolment.LearningPlatform)
                .Where(fileSubmission
                    => fileSubmission.EnrolmentAssignment.Enrolment.Course.Name == query.CourseName &&
                        fileSubmission.EnrolmentAssignment.Enrolment.LearningPlatform.Name == query.PlatformName)
                .ToListAsync();

            if (fileSubmissions.Count == 0)
            {
                return new ScatteringMeasuresOutputModel(0, 0, 0);
            }

            var fileSubmissionGroups = fileSubmissions
                .GroupBy(fileSubmission => fileSubmission.NumberOfFiles)
                .OrderBy(fileSubmissionGroup => fileSubmissionGroup.Count())
                .ToList();

            var minFileSubmission = fileSubmissions.Min(fileSubmission => fileSubmission.NumberOfFiles);
            var maxFileSubmission = fileSubmissions.Max(fileSubmission => fileSubmission.NumberOfFiles);
            var swing = maxFileSubmission - minFileSubmission;

            var fileSubmissionsNumberOfFiles = fileSubmissions.Select(fileSubmission => fileSubmission.NumberOfFiles);
            var averageNumberOfFiles = fileSubmissionsNumberOfFiles.Average();
            var sumOfSquaresOfDifferences = fileSubmissionsNumberOfFiles.Select(numberOfFiles => (numberOfFiles - averageNumberOfFiles) * (numberOfFiles - averageNumberOfFiles)).Sum();

            var dispersion = sumOfSquaresOfDifferences / fileSubmissionsNumberOfFiles.Count();
            var standardDeviation = Math.Sqrt(dispersion);

            return new ScatteringMeasuresOutputModel(swing, dispersion, standardDeviation);
        }
    }
}
