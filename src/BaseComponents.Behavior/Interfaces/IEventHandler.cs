namespace BaseComponents.Behavior.Interfaces;

public interface IEventHandler<TEvent>
    where TEvent : IEvent
{
    public Task HandleAsync(TEvent evnt);
}