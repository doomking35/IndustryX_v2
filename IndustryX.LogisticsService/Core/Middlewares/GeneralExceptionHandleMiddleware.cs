using System.Text.Json;
using IndustryX.LogisticsService.Core.Entities.Records;

namespace IndustryX.LogisticsService.Core.Middlewares;

public class GeneralExceptionHandleMiddleware(ILogger<GeneralExceptionHandleMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            logger.LogInformation("GeneralExceptionHandleMiddleware is running");
            await next(context);
            logger.LogInformation("GeneralExceptionHandleMiddleware is done");
        }
        catch (Exception e)
        {
            var exceptionHandleRecord = new GeneralExceptionHandleRecord()
            {
                ExceptionMessage = e.Message,
                ExceptionStatusCode = 500,
                ExceptionFrom = e.Source ?? ""
            };
            logger.LogError("GeneralExceptionHandleMiddleware caught an error!");
            context.Response.StatusCode = 500;
            await context.Response.WriteAsync(JsonSerializer.Serialize(exceptionHandleRecord));
        }

    }

   
}