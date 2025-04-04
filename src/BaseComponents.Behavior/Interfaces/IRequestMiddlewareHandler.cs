namespace BaseComponents.Behavior.Interfaces;

public interface IRequestMiddlewareHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public Task<TResponse> HandleAsync(
        TRequest request,
        Func<Task<TResponse>> next
    );
}