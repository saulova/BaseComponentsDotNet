namespace BaseComponents.Observability.Extensions;

public static class ApplicationBuilderJsonLoggerExtensions
{
    public static IApplicationBuilder SetJsonLoggerHttpContextAccessor(this IApplicationBuilder app)
    {
        var httpContextAccessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();

        JsonLogger.SetHttpContextAccessor(httpContextAccessor);

        return app;
    }
}