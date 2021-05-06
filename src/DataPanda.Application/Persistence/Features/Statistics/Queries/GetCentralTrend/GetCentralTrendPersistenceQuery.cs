using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;

namespace DataPanda.Application.Persistence.Features.Statistics.Queries.GetCentralTrend
{
    public class GetCentralTrendPersistenceQuery : IPersistenceQuery<CentralTrendOutputModel>
    {
        public GetCentralTrendPersistenceQuery(string courseName, string platformName)
        {
            CourseName = courseName;
            PlatformName = platformName;
        }

        public string CourseName { get; }

        public string PlatformName { get; }
    }
}
