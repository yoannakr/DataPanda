using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetCentralTrend;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DataPanda.Persistence.Features.Statistics.Queries.GetCentralTrendQuery
{
    public class GetCentralTrendPersistenceQueryHandler : IPersistenceQueryHandler<GetCentralTrendPersistenceQuery, CentralTrendOutputModel>
    {
        private readonly DataPandaDbContext context;

        public GetCentralTrendPersistenceQueryHandler(DataPandaDbContext context)
        {
            this.context = context;
        }

        public async Task<CentralTrendOutputModel> Handle(GetCentralTrendPersistenceQuery query)
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

            var fileSubmissionGroups = fileSubmissions
                .GroupBy(fileSubmission => fileSubmission.NumberOfFiles)
                .OrderBy(fileSubmissionGroup => fileSubmissionGroup.Count())
                .ToList();

            var modefileSubmission = fileSubmissionGroups.LastOrDefault();
            var mode = modefileSubmission?.Key ?? -1;
            var modeFrequency = modefileSubmission?.Count() ?? -1;

            var groupsCount = fileSubmissionGroups.Count;
            var middleGroupIndex = groupsCount / 2;

            var median = groupsCount % 2 != 0 ?
                fileSubmissionGroups[middleGroupIndex].Key :
                (double)(fileSubmissionGroups[middleGroupIndex].Key + fileSubmissionGroups[middleGroupIndex + 1].Key) / 2;

            var average = (double)fileSubmissionGroups.Sum(fileSubmissionGroup => fileSubmissionGroup.Key) / (double)fileSubmissionGroups.Count();
            var averaggeWithWeight = fileSubmissions.Average(fileSubmission => fileSubmission.NumberOfFiles);

            return new CentralTrendOutputModel(mode, modeFrequency, median, average, averaggeWithWeight);
        }
    }
}
