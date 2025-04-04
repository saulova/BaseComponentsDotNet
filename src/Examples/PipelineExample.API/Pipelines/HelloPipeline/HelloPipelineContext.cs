namespace PipelineExample.API.Pipelines.HelloPipeline;

public class HelloPipelineContext(string name) : IPipelineContext
{
    public string Name { get; set; } = name;
    public string Text { get; set; } = "";
}