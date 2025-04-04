namespace BaseComponents.Behavior;

public class Mediator
{
    protected readonly IServiceProvider _serviceProvider;

    public Mediator(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected IRequestHandler<TRequest, TResponse> GetRequestHandler<TRequest, TResponse>()
        where TRequest : IRequest<TResponse>
    {
        var handler = _serviceProvider.GetKeyedService<IRequestHandler<TRequest, TResponse>>(typeof(TRequest));

        Guard.IsNotNull(handler, $"No handler found for {typeof(TRequest).Name}");

        return handler;
    }

    protected List<IRequestMiddlewareHandler<TRequest, TResponse>> GetRequestMiddlewaresHandlers<TRequest, TResponse>()
        where TRequest : IRequest<TResponse>
    {
        List<IRequestMiddlewareHandler<TRequest, TResponse>> middlewares = [];

        var requestMiddlewares = _serviceProvider
            .GetKeyedServices<IRequestMiddlewareHandler<TRequest, TResponse>>(typeof(TRequest))
            .Reverse()
            .ToList();

        Console.WriteLine(requestMiddlewares.Count);

        middlewares.AddRange(requestMiddlewares ?? []);

        var defaultMiddlewares = _serviceProvider
            .GetServices<IRequestMiddlewareHandler<TRequest, TResponse>>()
            .Reverse()
            .ToList();

        middlewares.AddRange(defaultMiddlewares);

        return middlewares ?? [];
    }

    public async Task<TResponse> SendAsync<TRequest, TResponse>(TRequest request)
        where TRequest : IRequest<TResponse>
    {
        var handler = GetRequestHandler<TRequest, TResponse>();

        var middlewares = GetRequestMiddlewaresHandlers<TRequest, TResponse>();

        Func<Task<TResponse>> handlerDelegate = () => handler.HandleAsync(request);

        foreach (var middleware in middlewares)
        {
            var next = handlerDelegate;
            handlerDelegate = () => middleware.HandleAsync(request, next);
        }

        return await handlerDelegate();
    }

    protected IEventHandler<TEvent> GetEventHandler<TEvent>()
        where TEvent : IEvent
    {
        var handler = _serviceProvider.GetKeyedService<IEventHandler<TEvent>>(typeof(TEvent));

        Guard.IsNotNull(handler, $"No handler found for {typeof(TEvent).Name}");

        return handler;
    }

    protected List<IEventMiddlewareHandler<TEvent>> GetEventMiddlewaresHandlers<TEvent>()
        where TEvent : IEvent
    {
        List<IEventMiddlewareHandler<TEvent>> middlewares = [];

        var requestMiddlewares = _serviceProvider
            .GetKeyedServices<IEventMiddlewareHandler<TEvent>>(typeof(TEvent))
            .Reverse()
            .ToList();

        Console.WriteLine(requestMiddlewares.Count);

        middlewares.AddRange(requestMiddlewares ?? []);

        var defaultMiddlewares = _serviceProvider
            .GetServices<IEventMiddlewareHandler<TEvent>>()
            .Reverse()
            .ToList();

        middlewares.AddRange(defaultMiddlewares);

        return middlewares ?? [];
    }

    public async Task DispatchAsync<TEvent>(TEvent evnt)
        where TEvent : IEvent
    {
        var handler = GetEventHandler<TEvent>();

        var middlewares = GetEventMiddlewaresHandlers<TEvent>();

        Func<Task> handlerDelegate = () => handler.HandleAsync(evnt);

        foreach (var middleware in middlewares)
        {
            var next = handlerDelegate;
            handlerDelegate = () => middleware.HandleAsync(evnt, next);
        }

        await handlerDelegate();
    }

    protected List<IPipelineOperation<TPipelineContext>> GetPipelineOperations<TPipelineContext>()
        where TPipelineContext : IPipelineContext
    {
        var pipelineOperations = _serviceProvider.GetKeyedServices<IPipelineOperation<TPipelineContext>>(typeof(TPipelineContext)).ToList();

        if (pipelineOperations.Count == 0)
        {
            throw new InvalidOperationException($"No operation found for {typeof(TPipelineContext).Name}");
        }

        return pipelineOperations;
    }

    public async Task<TPipelineContext> SendThroughPipelineAsync<TPipelineContext>(TPipelineContext pipelineContext)
         where TPipelineContext : IPipelineContext
    {
        foreach (var operation in GetPipelineOperations<TPipelineContext>())
        {
            pipelineContext = await operation.ExecuteAsync(pipelineContext);
        }

        return pipelineContext;
    }
}