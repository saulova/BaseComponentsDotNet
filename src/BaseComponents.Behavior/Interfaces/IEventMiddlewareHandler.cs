namespace BaseComponents.Behavior.Interfaces;

public interface IEventMiddlewareHandler<TEvent>
    where TEvent : IEvent
{
    public Task HandleAsync(
        TEvent evnt,
        Func<Task> next
    );
}