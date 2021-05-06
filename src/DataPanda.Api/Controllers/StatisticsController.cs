using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend;
using DataPanda.Application.Features.Statistics.Queries.GetCentralTrend.Models;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DataPanda.Api.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly IQueryHandler<GetFrequencyDistributionQuery, FrequencyDistributionOutputModel> getFrequencyDistributionQueryHandler;
        private readonly IQueryHandler<GetCentralTrendQuery, CentralTrendOutputModel> getCentralTrendQueryHandler;

        public StatisticsController(
            IQueryHandler<GetFrequencyDistributionQuery, FrequencyDistributionOutputModel> getFrequencyDistributionQueryHandler,
            IQueryHandler<GetCentralTrendQuery, CentralTrendOutputModel> getCentralTrendQueryHandler)
        {
            this.getFrequencyDistributionQueryHandler = getFrequencyDistributionQueryHandler;
            this.getCentralTrendQueryHandler = getCentralTrendQueryHandler;
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
    }
}
