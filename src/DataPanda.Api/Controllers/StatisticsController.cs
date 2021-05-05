using DataPanda.Application.Contracts.CQRS.Queries;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution;
using DataPanda.Application.Features.Statistics.Queries.GetFrequencyDistribution.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DataPanda.Api.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly IQueryHandler<GetFrequencyDistributionQuery, FrequencyDistributionOutputModel> getFrequencyDistributionQueryHandler;

        public StatisticsController(IQueryHandler<GetFrequencyDistributionQuery, FrequencyDistributionOutputModel> getFrequencyDistributionQueryHandler)
        {
            this.getFrequencyDistributionQueryHandler = getFrequencyDistributionQueryHandler;
        }

        [HttpGet]
        public async Task<ActionResult> FrequencyDistribution()
        {
            var result = await getFrequencyDistributionQueryHandler.Handle(new GetFrequencyDistributionQuery());

            return new OkObjectResult(result);
        }
    }
}
