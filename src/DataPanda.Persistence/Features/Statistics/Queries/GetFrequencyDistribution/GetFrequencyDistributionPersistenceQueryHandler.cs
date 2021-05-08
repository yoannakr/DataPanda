using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetFrequencyDistribution;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Features.Statistics.Queries.GetFrequencyDistribution
{
    public class GetFrequencyDistributionPersistenceQueryHandler : IPersistenceQueryHandler<GetFrequencyDistributionPersistenceQuery, FrequencyDistributionOutputModel>
    {
        private readonly DataPandaDbContext context;

        public GetFrequencyDistributionPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<FrequencyDistributionOutputModel> Handle(GetFrequencyDistributionPersistenceQuery query)
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

            var frequencyDistributions = new List<FrequencyDistribution>();

            if (fileSubmissions.Count == 0)
            {
                return new FrequencyDistributionOutputModel(frequencyDistributions, 0, 0);
            }

            var fileSubmissionGroups = fileSubmissions.GroupBy(fileSubmission => fileSubmission.NumberOfFiles).ToList();

            var totalAbsoluteFrequency = fileSubmissionGroups
                .Sum(fileSubmissionGroup => fileSubmissionGroup.Count());

            foreach (var fileSubmissionGroup in fileSubmissionGroups)
            {
                var numberOfSubmissions = fileSubmissionGroup.Key;
                var absoluteFrequency = fileSubmissionGroup.Count();
                var relativeFrequency = ((double)absoluteFrequency / (double)totalAbsoluteFrequency) * 100;
                relativeFrequency = Math.Round(relativeFrequency, 1);

                var frequencyDistribution = new FrequencyDistribution(numberOfSubmissions, absoluteFrequency, relativeFrequency);
                frequencyDistributions.Add(frequencyDistribution);
            }

            var totalRelativeFrequency = frequencyDistributions.Sum(frequencyDistribution => frequencyDistribution.RelativeFrequency);

            return new FrequencyDistributionOutputModel(frequencyDistributions, totalAbsoluteFrequency, totalRelativeFrequency);
        }
    }
}
