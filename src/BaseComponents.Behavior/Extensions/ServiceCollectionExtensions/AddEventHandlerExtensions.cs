namespace BaseComponents.Behavior.Extensions.ServiceCollectionExtensions;

public static partial class AddEventHandlerExtensions
{
    public static IServiceCollection AddEventHandlers(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>)))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            var interfaceType = handlerType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEventHandler<>));

            var eventType = interfaceType.GetGenericArguments()[0];

            services.AddKeyedTransient(interfaceType, eventType, handlerType);
        }

        return services;
    }

    public static IServiceCollection AddSingletonEventHandler<TEvent, TEventHandler>(this IServiceCollection services)
        where TEvent : IEvent
        where TEventHandler : class, IEventHandler<TEvent>
    {
        services.AddKeyedSingleton<IEventHandler<TEvent>, TEventHandler>(typeof(TEvent));

        return services;
    }

    public static IServiceCollection AddTransientEventHandler<TEvent, TEventHandler>(this IServiceCollection services)
        where TEvent : IEvent
        where TEventHandler : class, IEventHandler<TEvent>
    {
        services.AddKeyedTransient<IEventHandler<TEvent>, TEventHandler>(typeof(TEvent));

        return services;
    }

    public static IServiceCollection AddScopedEventHandler<TEvent, TEventHandler>(this IServiceCollection services)
        where TEvent : IEvent
        where TEventHandler : class, IEventHandler<TEvent>
    {
        services.AddKeyedScoped<IEventHandler<TEvent>, TEventHandler>(typeof(TEvent));

        return services;
    }
}