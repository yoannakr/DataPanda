using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis.Models;

namespace DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis
{
    public class GetCorrelationAnalysisQuery : IQuery<CorrelationAnalysisOutputModel>
    {
        public GetCorrelationAnalysisQuery(string courseName)
        {
            CourseName = courseName;
        }

        public string CourseName { get; }
    }
}
