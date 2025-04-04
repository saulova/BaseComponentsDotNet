namespace BaseComponents.Observability.Logger;

public class JsonLogState
{
    public string? CallerMember { get; set; } = null;
    public string? CallerFile { get; set; } = null;
    public int? CallerLine { get; set; } = null;
    public string Msg { get; set; } = string.Empty;
    public object? Input { get; set; }
    public object? Output { get; set; }
}