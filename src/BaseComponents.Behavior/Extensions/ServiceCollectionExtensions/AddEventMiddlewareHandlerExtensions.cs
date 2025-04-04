namespace BaseComponents.Behavior.Extensions.ServiceCollectionExtensions;

public static partial class AddEventMiddlewareHandlerExtensions
{
    public static IServiceCollection AddSingletonEventMiddlewareHandler<TEvent, TEventMiddlewareHandler>(this IServiceCollection services)
        where TEvent : IEvent
        where TEventMiddlewareHandler : class, IEventMiddlewareHandler<TEvent>
    {
        services.AddKeyedSingleton<IEventMiddlewareHandler<TEvent>, TEventMiddlewareHandler>(typeof(TEvent));

        return services;
    }

    public static IServiceCollection AddTransientEventMiddlewareHandler<TEvent, TEventMiddlewareHandler>(this IServiceCollection services)
        where TEvent : IEvent
        where TEventMiddlewareHandler : class, IEventMiddlewareHandler<TEvent>
    {
        services.AddKeyedTransient<IEventMiddlewareHandler<TEvent>, TEventMiddlewareHandler>(typeof(TEvent));

        return services;
    }

    public static IServiceCollection AddScopedEventMiddlewareHandler<TEvent, TEventMiddlewareHandler>(this IServiceCollection services)
        where TEvent : IEvent
        where TEventMiddlewareHandler : class, IEventMiddlewareHandler<TEvent>
    {
        services.AddKeyedScoped<IEventMiddlewareHandler<TEvent>, TEventMiddlewareHandler>(typeof(TEvent));

        return services;
    }

    public static IServiceCollection AddSingletonEventMiddlewareHandler<TEvent>(this IServiceCollection services, Type middlewareHandler)
        where TEvent : IEvent, IEventMiddlewareHandler<TEvent>
    {
        services.AddKeyedSingleton(typeof(IEventMiddlewareHandler<TEvent>), typeof(TEvent), middlewareHandler);

        return services;
    }

    public static IServiceCollection AddTransientEventMiddlewareHandler<TEvent>(this IServiceCollection services, Type middlewareHandler)
        where TEvent : IEvent, IEventMiddlewareHandler<TEvent>
    {
        services.AddKeyedTransient(typeof(IEventMiddlewareHandler<TEvent>), typeof(TEvent), middlewareHandler);

        return services;
    }

    public static IServiceCollection AddScopedEventMiddlewareHandler<TEvent>(this IServiceCollection services, Type middlewareHandler)
        where TEvent : IEvent, IEventMiddlewareHandler<TEvent>
    {
        services.AddKeyedScoped(typeof(IEventMiddlewareHandler<TEvent>), typeof(TEvent), middlewareHandler);

        return services;
    }
}