
namespace RequestHandlersExample.API.Endpoints;

public class HelloEndpoint : IAPIEndpoint<HelloRequest, HelloEndpointServices>
{
    public static void Configure(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HelloEndpoint.HandleAsync);
    }

    public static async Task<IResult> HandleAsync(HelloRequest request, [AsParameters] HelloEndpointServices services, CancellationToken cancellationToken)
    {
        var sayHelloCommand = new SayHelloCommand(request.Name ?? "");

        var result = await services.Mediator.SendAsync<SayHelloCommand, string>(sayHelloCommand);

        return TypedResults.Json(new HelloResponse(result));
    }
}