namespace EventHandlersExample.API.Endpoints;

public class HelloEndpoint : IAPIEndpoint<HelloRequest, HelloEndpointServices>
{
    public static void Configure(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HelloEndpoint.HandleAsync);
    }

    public static async Task<IResult> HandleAsync(HelloRequest request, [AsParameters] HelloEndpointServices services, CancellationToken cancellationToken)
    {
        var sayHelloEvent = new SayHelloEvent(request.Name ?? "");

        await services.Mediator.DispatchAsync(sayHelloEvent);

        return TypedResults.Json(new HelloResponse());
    }
}