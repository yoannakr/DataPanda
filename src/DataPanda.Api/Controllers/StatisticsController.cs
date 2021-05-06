using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;
using DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures;
using DataPanda.Application.Features.Statistics.Queries.GetScatteringMeasures.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DataPanda.Api.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly IQueryHandler<GetFrequencyDistributionQuery, FrequencyDistributionOutputModel> getFrequencyDistributionQueryHandler;
        private readonly IQueryHandler<GetCentralTrendQuery, CentralTrendOutputModel> getCentralTrendQueryHandler;
        private readonly IQueryHandler<GetScatteringMeasuresQuery, ScatteringMeasuresOutputModel> getScatteringMeasuresQueryHandler;

        public StatisticsController(
            IQueryHandler<GetFrequencyDistributionQuery, FrequencyDistributionOutputModel> getFrequencyDistributionQueryHandler,
            IQueryHandler<GetCentralTrendQuery, CentralTrendOutputModel> getCentralTrendQueryHandler,
            IQueryHandler<GetScatteringMeasuresQuery, ScatteringMeasuresOutputModel> getScatteringMeasuresQueryHandler)
        {
            this.getFrequencyDistributionQueryHandler = getFrequencyDistributionQueryHandler;
            this.getCentralTrendQueryHandler = getCentralTrendQueryHandler;
            this.getScatteringMeasuresQueryHandler = getScatteringMeasuresQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult> FrequencyDistribution()
        {
            var result = await getFrequencyDistributionQueryHandler.Handle(new GetFrequencyDistributionQuery());

            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<ActionResult> CentralTrend()
        {
            var result = await getCentralTrendQueryHandler.Handle(new GetCentralTrendQuery());

            return new OkObjectResult(result);
        }

        [HttpGet]
        public async Task<ActionResult> ScatteringMeasures()
        {
            var result = await getScatteringMeasuresQueryHandler.Handle(new GetScatteringMeasuresQuery());

            return new OkObjectResult(result);
        }
    }
}
