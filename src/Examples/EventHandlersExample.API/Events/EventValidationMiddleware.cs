namespace EventHandlersExample.API.Events;

public class EventValidationMiddleware<TEvent> : IEventMiddlewareHandler<TEvent>
    where TEvent : IEvent
{
    public async Task HandleAsync(TEvent evnt, Func<Task> next)
    {
        var name = evnt.TryGetPropertyValue("Name", "");

        Guard.IsNotNullOrWhiteSpace(name, "Name can not be null or white space!");

        await next();
    }
}