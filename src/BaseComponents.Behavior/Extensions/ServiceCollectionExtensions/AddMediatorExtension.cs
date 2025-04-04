namespace BaseComponents.Behavior.Extensions.ServiceCollectionExtensions;

public static partial class AddMediatorExtension
{
    public static IServiceCollection AddMediator(this IServiceCollection services)
    {
        services.AddSingleton<Mediator>();

        return services;
    }
}