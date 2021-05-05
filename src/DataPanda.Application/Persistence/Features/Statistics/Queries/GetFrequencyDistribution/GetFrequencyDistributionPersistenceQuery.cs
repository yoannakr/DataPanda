using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;

namespace DataPanda.Application.Persistence.Features.Statistics.Queries.GetFrequencyDistribution
{
    public class GetFrequencyDistributionPersistenceQuery : IPersistenceQuery<FrequencyDistributionOutputModel>
    {
    }
}
