namespace RequestHandlersExample.API.Commands;

public class LoggingMiddleware<TRequest, TResponse>(ILogger<LoggingMiddleware<TRequest, TResponse>> logger) : IRequestMiddlewareHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingMiddleware<TRequest, TResponse>> _logger = logger;

    public async Task<TResponse> HandleAsync(TRequest request, Func<Task<TResponse>> next)
    {
        _logger.Info($"[LOG] Running {typeof(TRequest).Name}");

        var response = await next();

        _logger.Info($"[LOG] Finished {typeof(TRequest).Name}");

        return response;
    }
}