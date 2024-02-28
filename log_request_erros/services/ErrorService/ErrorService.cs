using Microsoft.AspNetCore.Mvc;

namespace log_request_erros.services.ErrorService;

public static class ErrorService
{
    // Result 'padrão' do ASP.NET Core, pode ser melhorado?- talvez, não pesquisei afundo.
    public static BadRequestObjectResult Result(
        ActionContext context)
    {
        var problemDetails = new ValidationProblemDetails(context.ModelState)
        {
            //Type = "https://github.com/IcaroFranco/log_request_errors",
            Title = "One or more model validation errors occurred.",
            Status = StatusCodes.Status400BadRequest,
            Detail = "See the errors property for details",
            Instance = context.HttpContext.Request.Path
        };

        problemDetails.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

        LogService.LogService.Log(problemDetails);

        return new BadRequestObjectResult(problemDetails)
        {
            ContentTypes = { "application/problem+json" }
        };
    }
}
