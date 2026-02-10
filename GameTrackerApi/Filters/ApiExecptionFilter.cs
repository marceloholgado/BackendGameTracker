using GameTracker.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace GameTracker.Api.Filters
{
    public class ApiExecptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.Result = context.Exception switch
            {
                GameNotFoundException => new NotFoundObjectResult(
                    new { message = context.Exception.Message }
                ),
                DomainException => new BadRequestObjectResult(
                    new { message = context.Exception.Message }
                ),
                _ => new ObjectResult(new { message = "Internal server error" })
                {
                    StatusCode = 500
                }
            };

            context.ExceptionHandled = true;
        }
    }
}
