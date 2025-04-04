namespace BaseComponents.Behavior.Interfaces;

public interface IPipelineOperation<TPipelineContext> where TPipelineContext : IPipelineContext
{
    public Task<TPipelineContext> ExecuteAsync(TPipelineContext pipelineContext);
}
