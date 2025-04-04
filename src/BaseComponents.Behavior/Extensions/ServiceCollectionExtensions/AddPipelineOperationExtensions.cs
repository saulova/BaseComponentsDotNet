namespace BaseComponents.Behavior.Extensions.ServiceCollectionExtensions;

public static partial class AddPipelineOperationExtensions
{
    public static IServiceCollection AddTransientPipelineOperation<TPipelineContext, TPipelineOperation>(this IServiceCollection services)
        where TPipelineContext : IPipelineContext
        where TPipelineOperation : class, IPipelineOperation<TPipelineContext>
    {
        services.AddKeyedTransient<IPipelineOperation<TPipelineContext>, TPipelineOperation>(typeof(TPipelineContext));

        return services;
    }

    public static IServiceCollection AddSingletonPipelineOperation<TPipelineContext, TPipelineOperation>(this IServiceCollection services)
        where TPipelineContext : IPipelineContext
        where TPipelineOperation : class, IPipelineOperation<TPipelineContext>
    {
        services.AddKeyedSingleton<IPipelineOperation<TPipelineContext>, TPipelineOperation>(typeof(TPipelineContext));

        return services;
    }

    public static IServiceCollection AddScopedPipelineOperation<TPipelineContext, TPipelineOperation>(this IServiceCollection services)
        where TPipelineContext : IPipelineContext
        where TPipelineOperation : class, IPipelineOperation<TPipelineContext>
    {
        services.AddKeyedScoped<IPipelineOperation<TPipelineContext>, TPipelineOperation>(typeof(TPipelineContext));

        return services;
    }
}