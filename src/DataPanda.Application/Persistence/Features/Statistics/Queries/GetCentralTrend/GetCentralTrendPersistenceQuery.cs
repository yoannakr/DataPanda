using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;

namespace DataPanda.Application.Persistence.Features.Statistics.Queries.GetCentralTrend
{
    public class GetCentralTrendPersistenceQuery : IPersistenceQuery<CentralTrendOutputModel>
    {
    }
}
