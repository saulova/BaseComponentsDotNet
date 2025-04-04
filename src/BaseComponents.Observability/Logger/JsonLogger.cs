namespace BaseComponents.Observability.Logger;

public class JsonLogger : ILogger
{
    private readonly JsonLoggerOptions _options;
    private readonly JsonSerializerOptions _jsonSerializerOptions;
    private readonly string _category;
    private readonly object _lock = new();

    private static IHttpContextAccessor? _httpContextAccessor;

    public JsonLogger(string category, JsonLoggerOptions options)
    {
        _category = category;
        _options = options;
        _jsonSerializerOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Encoder = options.JsonEncoder,
            PropertyNamingPolicy = options.PropertyNamingPolicy
        };
    }

    public static void SetHttpContextAccessor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IDisposable BeginScope<TState>(TState state)
        where TState : notnull
    {
        return new NoOpJsonLoggerScopeDisposable();
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return logLevel >= _options.MinimumLogLevel;
    }

    public static int ToNumericLevel(LogLevel logLevel)
    {
        return logLevel switch
        {
            LogLevel.Trace => 10,
            LogLevel.Debug => 20,
            LogLevel.Information => 30,
            LogLevel.Warning => 40,
            LogLevel.Error => 50,
            LogLevel.Critical => 60,
            _ => 0
        };
    }

    private string? GetRequestId()
    {
        return _httpContextAccessor?.HttpContext?.Request?.Headers?[_options.RequestIdHeaderName];
    }

    private string CreateJsonLogEntryUsingDefaultLog<TState>(LogLevel logLevel, TState state, Exception? exception)
    {
        var logEntry = new JsonLogEntry
        {
            Time = DateTime.UtcNow,
            Level = ToNumericLevel(logLevel),
            Category = _category,
            RequestId = GetRequestId(),
            Msg = state?.ToString() ?? "",
            Exception = exception?.ToString()
        };

        return JsonSerializer.Serialize(logEntry, _jsonSerializerOptions);
    }

    private string CreateJsonLogEntryUsingJsonLogState(LogLevel logLevel, JsonLogState jsonLogState, Exception? exception)
    {
        var logEntry = new JsonLogEntry
        {
            Time = DateTime.UtcNow,
            Level = ToNumericLevel(logLevel),
            Category = _category,
            CallerMember = jsonLogState.CallerMember,
            CallerFile = jsonLogState.CallerFile,
            CallerLine = jsonLogState.CallerLine,
            RequestId = GetRequestId(),
            Msg = jsonLogState.Msg,
            Exception = exception?.ToString(),
            Input = jsonLogState.Input,
            Output = jsonLogState.Output
        };

        return JsonSerializer.Serialize(logEntry, _jsonSerializerOptions);
    }


    private string CreateLogString<TState>(LogLevel logLevel, TState state, Exception? exception)
    {
        return state switch
        {
            JsonLogState jsonLogState => CreateJsonLogEntryUsingJsonLogState(logLevel, jsonLogState, exception),
            _ => CreateJsonLogEntryUsingDefaultLog(logLevel, state, exception)
        };
    }

    public void Log<TState>(
        LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter
    )
    {
        if (!IsEnabled(logLevel)) return;

        var jsonLog = CreateLogString(logLevel, state, exception);

        Console.WriteLine(jsonLog);

        if (_options.EnableFileLogging)
        {
            lock (_lock)
            {
                File.AppendAllText(_options.LogFilePath, $"{jsonLog}{Environment.NewLine}");
            }
        }
    }
}

public class NoOpJsonLoggerScopeDisposable : IDisposable
{
    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}