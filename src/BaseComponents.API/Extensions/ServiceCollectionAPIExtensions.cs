using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace BaseComponents.API.Extensions;

public static partial class DefaultServicesDependencyInjection
{
    public static IServiceCollection AddAPIDefaultServices(this IServiceCollection services)
    {
        services.ConfigureHttpClientDefaults(http => { });

        services.AddHttpContextAccessor();

        services.AddHealthChecks()
            .AddCheck("self", () => HealthCheckResult.Healthy(), ["live"]);

        services.AddEndpointsApiExplorer();
        services.AddOpenApiDocument();

        services.AddExceptionHandler<UnexpectedExceptionHandler>();

        return services;
    }
}