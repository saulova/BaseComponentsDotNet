namespace RequestHandlersExample.API.Commands;

public class SayHelloCommand(string name) : IRequest<string>
{
    public string Name { get; set; } = name;
}