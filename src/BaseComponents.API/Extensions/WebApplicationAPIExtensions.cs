using Microsoft.AspNetCore.Diagnostics.HealthChecks;

namespace BaseComponents.API.Extensions;

public static class WebApplicationAPIExtensions
{
    public static WebApplication MapAPIDefaultServicesEndpoints(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.MapHealthChecks("/health");
            app.MapHealthChecks("/alive", new HealthCheckOptions
            {
                Predicate = r => r.Tags.Contains("live")
            });
        }

        return app;
    }

    public static IApplicationBuilder MapAPIEndpoints(
        this WebApplication app,
        Assembly assembly,
        RouteGroupBuilder? routeGroupBuilder = null)
    {
        app.MapAPIDefaultServicesEndpoints();

        var endpointTypes = assembly
            .DefinedTypes
            .Where(type => type is { IsAbstract: false, IsInterface: false })
            .Where(type => type.GetInterfaces().Any(i =>
                i == typeof(IAPIEndpoint) || i.IsGenericType && (
                       i.GetGenericTypeDefinition() == typeof(IAPIEndpoint<>) ||
                       i.GetGenericTypeDefinition() == typeof(IAPIEndpoint<,>)
                ))
            )
            .ToArray();

        IEndpointRouteBuilder builder = routeGroupBuilder is null ? app : routeGroupBuilder;

        foreach (var type in endpointTypes)
        {
            var configureMethod = type.GetMethod(
                "Configure",
                BindingFlags.Static | BindingFlags.Public
            );

            configureMethod?.Invoke(null, [builder]);
        }

        return app;
    }
}