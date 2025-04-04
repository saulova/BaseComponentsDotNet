namespace RequestHandlersExample.API.Commands;

public class SayHelloCommandHandler : IRequestHandler<SayHelloCommand, string>
{
    public Task<string> HandleAsync(SayHelloCommand command)
    {
        var hello = $"Hello {command.Name}";

        return Task.FromResult(hello);
    }
}