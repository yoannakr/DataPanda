using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;

namespace DataPanda.Application.Features.Statistics.Queries.GetCentralTrend
{
    public class GetCentralTrendQuery : IQuery<CentralTrendOutputModel>
    {
        public GetCentralTrendQuery(string courseName, string platformName)
        {
            CourseName = courseName;
            PlatformName = platformName;
        }

        public string CourseName { get; }

        public string PlatformName { get; }
    }
}
