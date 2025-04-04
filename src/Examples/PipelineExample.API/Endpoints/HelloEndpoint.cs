namespace PipelineExample.API.Endpoints;

public class HelloEndpoint : IAPIEndpoint<HelloRequest, HelloEndpointServices>
{
    public static void Configure(IEndpointRouteBuilder app)
    {
        app.MapPost("/", HelloEndpoint.HandleAsync);
    }

    public static async Task<IResult> HandleAsync(HelloRequest request, [AsParameters] HelloEndpointServices services, CancellationToken cancellationToken)
    {
        var pipelineContext = new HelloPipelineContext(request.Name ?? "");

        await services.Mediator.SendThroughPipelineAsync(pipelineContext);

        return TypedResults.Json(new HelloResponse(pipelineContext.Text));
    }
}