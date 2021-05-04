using DataPanda.Application.Contracts.CQRS.Results;
using Microsoft.AspNetCore.Mvc;

namespace DataPanda.Api.Extensions
{
    public static class ResultExtensions
    {
        public static ActionResult<TSuccessPayload> ToActionResult<TSuccessPayload>(this Result<TSuccessPayload> result)
        {
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(result.FailurePayload);
            }

            return result.SuccessPayload;
        }

        public static ActionResult ToActionResult(this Result result)
        {
            if (!result.Succeeded)
            {
                return new BadRequestObjectResult(result.FailurePayload);
            }

            return new OkResult();
        }
    }
}
