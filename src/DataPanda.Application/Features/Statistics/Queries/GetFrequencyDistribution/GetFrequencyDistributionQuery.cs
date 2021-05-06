using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;

namespace DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution
{
    public class GetFrequencyDistributionQuery : IQuery<FrequencyDistributionOutputModel>
    {
        public GetFrequencyDistributionQuery(string courseName, string platformName)
        {
            CourseName = courseName;
            PlatformName = platformName;
        }

        public string CourseName { get; }

        public string PlatformName { get; }
    }
}
