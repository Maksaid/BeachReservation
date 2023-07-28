using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Middlewares;

public class GlobalExceptionHandlingMiddleware : IMiddleware
{
    private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;

    public GlobalExceptionHandlingMiddleware(ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next(context);
        }
        catch (Exception e)
        {
            _logger.LogError(e,e.Message);
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            ProblemDetails problem = new()
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Type = "ServerError",
                Title = e.GetType().ToString(),
                Detail = e.Message
            };

            var json =  JsonSerializer.Serialize(problem);
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(json);

        }
    }
}