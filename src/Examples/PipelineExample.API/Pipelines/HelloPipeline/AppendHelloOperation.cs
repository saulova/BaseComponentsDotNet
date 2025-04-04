namespace PipelineExample.API.Pipelines.HelloPipeline;

public class AppendHelloOperation : IPipelineOperation<HelloPipelineContext>
{
    public Task<HelloPipelineContext> ExecuteAsync(HelloPipelineContext pipelineContext)
    {
        pipelineContext.Text = "Hello";

        return Task.FromResult(pipelineContext);
    }
}