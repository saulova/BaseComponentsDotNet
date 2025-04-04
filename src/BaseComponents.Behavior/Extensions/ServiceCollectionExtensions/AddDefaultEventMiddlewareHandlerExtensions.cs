namespace BaseComponents.Behavior.Extensions.ServiceCollectionExtensions;

public static partial class AddDefaultEventMiddlewareHandlerExtensions
{
    public static IServiceCollection AddSingletonDefaultEventMiddlewareHandler<TEventMiddlewareHandler>(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IEventMiddlewareHandler<>), typeof(TEventMiddlewareHandler));

        return services;
    }

    public static IServiceCollection AddTransientDefaultEventMiddlewareHandler<TEventMiddlewareHandler>(this IServiceCollection services)
    {
        services.AddTransient(typeof(IEventMiddlewareHandler<>), typeof(TEventMiddlewareHandler));

        return services;
    }

    public static IServiceCollection AddScopedDefaultEventMiddlewareHandler<TEventMiddlewareHandler>(this IServiceCollection services)
    {
        services.AddScoped(typeof(IEventMiddlewareHandler<>), typeof(TEventMiddlewareHandler));

        return services;
    }

    public static IServiceCollection AddSingletonDefaultEventMiddlewareHandler(this IServiceCollection services, Type middlewareHandler)
    {
        services.AddSingleton(typeof(IEventMiddlewareHandler<>), middlewareHandler);

        return services;
    }

    public static IServiceCollection AddTransientDefaultEventMiddlewareHandler(this IServiceCollection services, Type middlewareHandler)
    {
        services.AddTransient(typeof(IEventMiddlewareHandler<>), middlewareHandler);

        return services;
    }

    public static IServiceCollection AddScopedDefaultEventMiddlewareHandler(this IServiceCollection services, Type middlewareHandler)
    {
        services.AddScoped(typeof(IEventMiddlewareHandler<>), middlewareHandler);

        return services;
    }
}