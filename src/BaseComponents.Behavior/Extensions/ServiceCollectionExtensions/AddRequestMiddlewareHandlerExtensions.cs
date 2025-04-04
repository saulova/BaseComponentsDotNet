namespace BaseComponents.Behavior.Extensions.ServiceCollectionExtensions;

public static partial class AddRequestMiddlewareHandlerExtensions
{
    public static IServiceCollection AddSingletonRequestMiddlewareHandler<TRequest, TMiddlewareHandler, TResponse>(this IServiceCollection services)
        where TRequest : IRequest<TResponse>
        where TMiddlewareHandler : class, IRequestMiddlewareHandler<TRequest, TResponse>
    {
        services.AddKeyedSingleton<IRequestMiddlewareHandler<TRequest, TResponse>, TMiddlewareHandler>(typeof(TRequest));

        return services;
    }

    public static IServiceCollection AddTransientRequestMiddlewareHandler<TRequest, TMiddlewareHandler, TResponse>(this IServiceCollection services)
        where TRequest : IRequest<TResponse>
        where TMiddlewareHandler : class, IRequestMiddlewareHandler<TRequest, TResponse>
    {
        services.AddKeyedTransient<IRequestMiddlewareHandler<TRequest, TResponse>, TMiddlewareHandler>(typeof(TRequest));

        return services;
    }

    public static IServiceCollection AddScopedRequestMiddlewareHandler<TRequest, TMiddlewareHandler, TResponse>(this IServiceCollection services)
        where TRequest : IRequest<TResponse>
        where TMiddlewareHandler : class, IRequestMiddlewareHandler<TRequest, TResponse>
    {
        services.AddKeyedScoped<IRequestMiddlewareHandler<TRequest, TResponse>, TMiddlewareHandler>(typeof(TRequest));

        return services;
    }

    public static IServiceCollection AddSingletonRequestMiddlewareHandler<TRequest, TResponse>(this IServiceCollection services, Type middlewareHandler)
        where TRequest : IRequest<TResponse>, IRequestMiddlewareHandler<TRequest, TResponse>
    {
        services.AddKeyedSingleton(typeof(IRequestMiddlewareHandler<TRequest, TResponse>), typeof(TRequest), middlewareHandler);

        return services;
    }

    public static IServiceCollection AddTransientRequestMiddlewareHandler<TRequest, TResponse>(this IServiceCollection services, Type middlewareHandler)
        where TRequest : IRequest<TResponse>, IRequestMiddlewareHandler<TRequest, TResponse>
    {
        services.AddKeyedTransient(typeof(IRequestMiddlewareHandler<TRequest, TResponse>), typeof(TRequest), middlewareHandler);

        return services;
    }

    public static IServiceCollection AddScopedRequestMiddlewareHandler<TRequest, TResponse>(this IServiceCollection services, Type middlewareHandler)
        where TRequest : IRequest<TResponse>, IRequestMiddlewareHandler<TRequest, TResponse>
    {
        services.AddKeyedScoped(typeof(IRequestMiddlewareHandler<TRequest, TResponse>), typeof(TRequest), middlewareHandler);

        return services;
    }
}