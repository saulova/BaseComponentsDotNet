namespace PipelineExample.API.Pipelines.HelloPipeline;

public class AppendNameOperation : IPipelineOperation<HelloPipelineContext>
{
    public Task<HelloPipelineContext> ExecuteAsync(HelloPipelineContext pipelineContext)
    {
        pipelineContext.Text = $"{pipelineContext.Text} {pipelineContext.Name}";

        return Task.FromResult(pipelineContext);
    }
}