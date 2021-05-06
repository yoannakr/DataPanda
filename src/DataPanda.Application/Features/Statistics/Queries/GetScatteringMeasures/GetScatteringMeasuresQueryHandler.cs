using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures.Models;
using DataPanda.Application.Persistence.Features.Statistics.Queries.GetScatteringMeasures;
using System.Threading.Tasks;

namespace DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures
{
    public class GetScatteringMeasuresQueryHandler : IQueryHandler<GetScatteringMeasuresQuery, ScatteringMeasuresOutputModel>
    {
        private readonly IPersistenceQueryHandler<GetScatteringMeasuresPersistenceQuery, ScatteringMeasuresOutputModel> getScatteringMeasuresPersistenceQueryHandler;

        public GetScatteringMeasuresQueryHandler(IPersistenceQueryHandler<GetScatteringMeasuresPersistenceQuery, ScatteringMeasuresOutputModel> getScatteringMeasuresPersistenceQueryHandler)
        {
            this.getScatteringMeasuresPersistenceQueryHandler = getScatteringMeasuresPersistenceQueryHandler;
        }

        public async Task<ScatteringMeasuresOutputModel> Handle(GetScatteringMeasuresQuery query)
            => await getScatteringMeasuresPersistenceQueryHandler.Handle(new GetScatteringMeasuresPersistenceQuery());
    }
}
