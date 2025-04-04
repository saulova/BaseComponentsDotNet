namespace BaseComponents.Behavior.Extensions.ServiceCollectionExtensions;

public static partial class AddDefaultRequestMiddlewareHandlerExtensions
{
    public static IServiceCollection AddSingletonDefaultRequestMiddlewareHandler<TMiddlewareHandler>(this IServiceCollection services)
    {
        services.AddSingleton(typeof(IRequestMiddlewareHandler<,>), typeof(TMiddlewareHandler));

        return services;
    }

    public static IServiceCollection AddTransientDefaultRequestMiddlewareHandler<TMiddlewareHandler>(this IServiceCollection services)
    {
        services.AddTransient(typeof(IRequestMiddlewareHandler<,>), typeof(TMiddlewareHandler));

        return services;
    }

    public static IServiceCollection AddScopedDefaultRequestMiddlewareHandler<TMiddlewareHandler>(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRequestMiddlewareHandler<,>), typeof(TMiddlewareHandler));

        return services;
    }

    public static IServiceCollection AddSingletonDefaultRequestMiddlewareHandler(this IServiceCollection services, Type middlewareHandler)
    {
        services.AddSingleton(typeof(IRequestMiddlewareHandler<,>), middlewareHandler);

        return services;
    }

    public static IServiceCollection AddTransientDefaultRequestMiddlewareHandler(this IServiceCollection services, Type middlewareHandler)
    {
        services.AddTransient(typeof(IRequestMiddlewareHandler<,>), middlewareHandler);

        return services;
    }

    public static IServiceCollection AddScopedDefaultRequestMiddlewareHandler(this IServiceCollection services, Type middlewareHandler)
    {
        services.AddScoped(typeof(IRequestMiddlewareHandler<,>), middlewareHandler);

        return services;
    }
}