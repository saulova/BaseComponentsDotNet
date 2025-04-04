namespace EventHandlersExample.API.Events;

public class SayHelloEvent(string name) : IEvent
{
    public string Name { get; set; } = name;
}