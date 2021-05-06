using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetFrequencyDistribution;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution
{
    public class GetFrequencyDistributionQueryHandler : IQueryHandler<GetFrequencyDistributionQuery, FrequencyDistributionOutputModel>
    {
        private readonly IPersistenceQueryHandler<GetFrequencyDistributionPersistenceQuery, FrequencyDistributionOutputModel> getFrequencyDistributionPersistenceQueryHandler;

        public GetFrequencyDistributionQueryHandler(IPersistenceQueryHandler<GetFrequencyDistributionPersistenceQuery, FrequencyDistributionOutputModel> getFrequencyDistributionPersistenceQueryHandler)
        {
            this.getFrequencyDistributionPersistenceQueryHandler = getFrequencyDistributionPersistenceQueryHandler;
        }

        public async Task<FrequencyDistributionOutputModel> Handle(GetFrequencyDistributionQuery query)
            => await getFrequencyDistributionPersistenceQueryHandler.Handle(new GetFrequencyDistributionPersistenceQuery(query.CourseName, query.PlatformName));
    }
}
