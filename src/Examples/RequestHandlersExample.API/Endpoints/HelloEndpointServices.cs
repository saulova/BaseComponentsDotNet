namespace RequestHandlersExample.API.Endpoints;

public class HelloEndpointServices(
    ILogger<HelloEndpoint> logger,
    Mediator mediator)
{
    public ILogger<HelloEndpoint> Logger { get; set; } = logger;
    public Mediator Mediator { get; set; } = mediator;
}
