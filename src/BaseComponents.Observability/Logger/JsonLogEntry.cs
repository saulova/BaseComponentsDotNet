namespace BaseComponents.Observability.Logger;

public class JsonLogEntry : JsonLogState
{
    public DateTime Time { get; set; } = DateTime.UtcNow;
    public int Pid { get; set; } = Environment.ProcessId;
    public string? RequestId { get; set; }
    public int Level { get; set; } = 0;
    public string Category { get; set; } = string.Empty;
    public string? Exception { get; set; }
}