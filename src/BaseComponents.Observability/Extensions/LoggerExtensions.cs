namespace BaseComponents.Observability.Extensions;

public static class LoggerExtensions
{
    private static void LogWithState(
        this ILogger logger, LogLevel level, string message, Exception? exception = null,
        object? input = null, object? output = null,
        [CallerMemberName] string callerMember = "",
        [CallerFilePath] string callerFile = "",
        [CallerLineNumber] int callerLine = 0)
    {
        var state = new JsonLogState
        {
            CallerMember = callerMember,
            CallerFile = callerFile,
            CallerLine = callerLine,
            Msg = message,
            Input = input,
            Output = output
        };

        logger.Log(level, new EventId(0), state, exception, static (s, ex) => s?.ToString() ?? "");
    }

    public static void Trace(
        this ILogger logger, string message, object? input = null, object? output = null,
        [CallerMemberName] string callerMember = "",
        [CallerFilePath] string callerFile = "",
        [CallerLineNumber] int callerLine = 0)
    {
        logger.LogWithState(LogLevel.Trace, message, null, input, output, callerMember, callerFile, callerLine);
    }

    public static void Debug(
        this ILogger logger, string message, object? input = null, object? output = null,
        [CallerMemberName] string callerMember = "",
        [CallerFilePath] string callerFile = "",
        [CallerLineNumber] int callerLine = 0)
    {
        logger.LogWithState(LogLevel.Debug, message, null, input, output, callerMember, callerFile, callerLine);
    }

    public static void Info(
        this ILogger logger, string message, object? input = null, object? output = null,
        [CallerMemberName] string callerMember = "",
        [CallerFilePath] string callerFile = "",
        [CallerLineNumber] int callerLine = 0)
    {
        logger.LogWithState(LogLevel.Information, message, null, input, output, callerMember, callerFile, callerLine);
    }

    public static void Warn(
        this ILogger logger, string message, object? input = null, object? output = null,
        [CallerMemberName] string callerMember = "",
        [CallerFilePath] string callerFile = "",
        [CallerLineNumber] int callerLine = 0)
    {
        logger.LogWithState(LogLevel.Warning, message, null, input, output, callerMember, callerFile, callerLine);
    }

    public static void Error(
        this ILogger logger, string message, Exception exception, object? input = null, object? output = null,
        [CallerMemberName] string callerMember = "",
        [CallerFilePath] string callerFile = "",
        [CallerLineNumber] int callerLine = 0)
    {
        logger.LogWithState(LogLevel.Error, message, exception, input, output, callerMember, callerFile, callerLine);
    }

    public static void Fatal(
        this ILogger logger, string message, Exception exception, object? input = null, object? output = null,
        [CallerMemberName] string callerMember = "",
        [CallerFilePath] string callerFile = "",
        [CallerLineNumber] int callerLine = 0)
    {
        logger.LogWithState(LogLevel.Critical, message, exception, input, output, callerMember, callerFile, callerLine);
    }
}
