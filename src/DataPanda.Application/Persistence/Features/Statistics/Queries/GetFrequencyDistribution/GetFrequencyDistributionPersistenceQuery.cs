using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;

namespace DataPanda.Application.Persistence.Features.Statistics.Queries.GetFrequencyDistribution
{
    public class GetFrequencyDistributionPersistenceQuery : IPersistenceQuery<FrequencyDistributionOutputModel>
    {
        public GetFrequencyDistributionPersistenceQuery(string courseName, string platformName)
        {
            CourseName = courseName;
            PlatformName = platformName;
        }

        public string CourseName { get; }

        public string PlatformName { get; }
    }
}
