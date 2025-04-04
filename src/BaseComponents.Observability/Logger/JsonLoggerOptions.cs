namespace BaseComponents.Observability.Logger;

public class JsonLoggerOptions
{
    public bool EnableFileLogging { get; set; } = false;
    public string LogFilePath { get; set; } = "logs.json";
    public LogLevel MinimumLogLevel { get; set; } = LogLevel.Information;
    public JavaScriptEncoder JsonEncoder { get; set; } = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;
    public JsonNamingPolicy PropertyNamingPolicy { get; set; } = JsonNamingPolicy.CamelCase;
    public string RequestIdHeaderName { get; set; } = "X-Request-ID";
}