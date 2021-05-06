using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetCentralTrend;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Statistics.Queries.GetCentralTrend
{
    public class GetCentralTrendQueryHandler : IQueryHandler<GetCentralTrendQuery, CentralTrendOutputModel>
    {
        private readonly IPersistenceQueryHandler<GetCentralTrendPersistenceQuery, CentralTrendOutputModel> getCentralTrendPersistenceQueryHandler;

        public GetCentralTrendQueryHandler(IPersistenceQueryHandler<GetCentralTrendPersistenceQuery, CentralTrendOutputModel> getCentralTrendPersistenceQueryHandler)
        {
            this.getCentralTrendPersistenceQueryHandler = getCentralTrendPersistenceQueryHandler;
        }

        public async Task<CentralTrendOutputModel> Handle(GetCentralTrendQuery query)
            => await getCentralTrendPersistenceQueryHandler.Handle(new GetCentralTrendPersistenceQuery(query.CourseName, query.PlatformName));
    }
}
