namespace BaseComponents.Observability.Extensions;

public static class LoggerFactoryJsonLoggerExtensions
{
    public static ILoggerFactory AddJsonLoggerProvider(this ILoggerFactory factory, JsonLoggerOptions options)
    {
        factory.AddProvider(new JsonLoggerProvider(options));

        return factory;
    }
}