namespace BaseComponents.Observability.Extensions;

public static class LoggingBuilderJsonLoggerExtensions
{
    public static ILoggingBuilder AddJsonLogger(this ILoggingBuilder builder, Action<JsonLoggerOptions>? configure = null)
    {
        var options = new JsonLoggerOptions();

        configure?.Invoke(options);
        builder.AddProvider(new JsonLoggerProvider(options));

        return builder;
    }

    public static ILoggingBuilder AddJsonLogger(this ILoggingBuilder builder, IConfiguration configuration)
    {
        var options = new JsonLoggerOptions();

        configuration.GetSection("JsonLogger").Bind(options);

        return builder.AddJsonLogger(opt =>
        {
            opt.LogFilePath = options.LogFilePath;
            opt.EnableFileLogging = options.EnableFileLogging;
            opt.MinimumLogLevel = options.MinimumLogLevel;
        });
    }
}