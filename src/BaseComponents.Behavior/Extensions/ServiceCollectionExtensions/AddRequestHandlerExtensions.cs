namespace BaseComponents.Behavior.Extensions.ServiceCollectionExtensions;

public static partial class AddRequestHandlerExtensions
{
    public static IServiceCollection AddRequestHandlers(this IServiceCollection services, Assembly assembly)
    {
        var handlerTypes = assembly.GetTypes()
            .Where(t => t.GetInterfaces()
            .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>)))
            .ToList();

        foreach (var handlerType in handlerTypes)
        {
            var interfaceType = handlerType.GetInterfaces()
                .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IRequestHandler<,>));

            var requestType = interfaceType.GetGenericArguments()[0];

            services.AddKeyedTransient(interfaceType, requestType, handlerType);
        }

        return services;
    }

    public static IServiceCollection AddSingletonRequestHandler<TRequest, THandler, TResponse>(this IServiceCollection services)
        where TRequest : IRequest<TResponse>
        where THandler : class, IRequestHandler<TRequest, TResponse>
    {
        services.AddKeyedSingleton<IRequestHandler<TRequest, TResponse>, THandler>(typeof(TRequest));

        return services;
    }

    public static IServiceCollection AddTransientRequestHandler<TRequest, THandler, TResponse>(this IServiceCollection services)
        where TRequest : IRequest<TResponse>
        where THandler : class, IRequestHandler<TRequest, TResponse>
    {
        services.AddKeyedTransient<IRequestHandler<TRequest, TResponse>, THandler>(typeof(TRequest));

        return services;
    }

    public static IServiceCollection AddScopedRequestHandler<TRequest, THandler, TResponse>(this IServiceCollection services)
        where TRequest : IRequest<TResponse>
        where THandler : class, IRequestHandler<TRequest, TResponse>
    {
        services.AddKeyedScoped<IRequestHandler<TRequest, TResponse>, THandler>(typeof(TRequest));

        return services;
    }
}