using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures.Models;

namespace DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures
{
    public class GetScatteringMeasuresQuery : IQuery<ScatteringMeasuresOutputModel>
    {
        public GetScatteringMeasuresQuery(string courseName, string platformName)
        {
            CourseName = courseName;
            PlatformName = platformName;
        }

        public string CourseName { get; }

        public string PlatformName { get; }
    }
}
