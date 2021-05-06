using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis.Models;

namespace DataPanda.Application.Persistence.Features.Statistics.Queries.GetCorrelationAnalysis
{
    public class GetCorrelationAnalysisPersistenceQuery : IPersistenceQuery<CorrelationAnalysisOutputModel>
    {
        public GetCorrelationAnalysisPersistenceQuery(string courseName)
        {
            CourseName = courseName;
        }

        public string CourseName { get; }
    }
}
