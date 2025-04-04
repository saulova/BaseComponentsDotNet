namespace BaseComponents.Observability.Logger;
public class JsonLoggerProvider : ILoggerProvider, ISupportExternalScope
{
    private readonly JsonLoggerOptions _options;
    private IExternalScopeProvider? _scopeProvider;
    private readonly ConcurrentDictionary<string, JsonLogger> _loggers = new();

    public JsonLoggerProvider(JsonLoggerOptions options)
    {
        _options = options;
    }

    public ILogger CreateLogger(string categoryName)
    {
        return _loggers.GetOrAdd(categoryName, name => new JsonLogger(name, _options));
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _loggers.Clear();
    }

    public void SetScopeProvider(IExternalScopeProvider scopeProvider)
    {
        _scopeProvider = scopeProvider;
    }
}