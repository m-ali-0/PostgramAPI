namespace PostgramAPI.Services;

public class ErrorHandler
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ErrorHandler> _logger;

    public ErrorHandler(
        RequestDelegate next,
        ILogger<ErrorHandler> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (UnauthorizedAccessException e)
        {
            _logger.LogError(e.Message + " at {time}", DateTime.Now);
            context.Response.StatusCode = 401;
            context.Response.ContentType = "application/json";
            var result = System.Text.Json.JsonSerializer.Serialize(new { message = e.Message });
            await context.Response.WriteAsync(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message + " at {time}", DateTime.Now);
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            var result = System.Text.Json.JsonSerializer.Serialize(new { message = e.Message });
            await context.Response.WriteAsync(result);
        }
    }
}