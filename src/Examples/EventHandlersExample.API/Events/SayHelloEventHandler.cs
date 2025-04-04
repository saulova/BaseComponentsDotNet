namespace EventHandlersExample.API.Events;

public class SayHelloEventHandler : IEventHandler<SayHelloEvent>
{
    public Task HandleAsync(SayHelloEvent evnt)
    {
        var hello = $"Hello {evnt.Name}";

        Console.WriteLine("");
        Console.WriteLine(hello);
        Console.WriteLine("");

        return Task.CompletedTask;
    }
}