using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetCorrelationAnalysis;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Statistics.Queries.GetCorrelationAnalysis
{
    public class GetCorrelationAnalysisQueryHandler : IQueryHandler<GetCorrelationAnalysisQuery, CorrelationAnalysisOutputModel>
    {
        private readonly IPersistenceQueryHandler<GetCorrelationAnalysisPersistenceQuery, CorrelationAnalysisOutputModel> getCorrelationAnalysisPersistenceQueryHandler;

        public GetCorrelationAnalysisQueryHandler(IPersistenceQueryHandler<GetCorrelationAnalysisPersistenceQuery, CorrelationAnalysisOutputModel> getCorrelationAnalysisPersistenceQueryHandler)
        {
            this.getCorrelationAnalysisPersistenceQueryHandler = getCorrelationAnalysisPersistenceQueryHandler;
        }

        public async Task<CorrelationAnalysisOutputModel> Handle(GetCorrelationAnalysisQuery query)
            => await getCorrelationAnalysisPersistenceQueryHandler.Handle(new GetCorrelationAnalysisPersistenceQuery());
    }
}
