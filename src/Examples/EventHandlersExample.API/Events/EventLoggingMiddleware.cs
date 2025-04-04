namespace EventHandlersExample.API.Events;

public class EventLoggingMiddleware<TEvent>(ILogger<EventLoggingMiddleware<TEvent>> logger) : IEventMiddlewareHandler<TEvent>
    where TEvent : IEvent
{
    private readonly ILogger<EventLoggingMiddleware<TEvent>> _logger = logger;

    public async Task HandleAsync(TEvent evnt, Func<Task> next)
    {
        _logger.Info($"[LOG] Running {typeof(TEvent).Name}");

        await next();

        _logger.Info($"[LOG] Finished {typeof(TEvent).Name}");
    }
}