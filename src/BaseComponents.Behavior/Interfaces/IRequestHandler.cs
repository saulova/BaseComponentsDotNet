namespace BaseComponents.Behavior.Interfaces;

public interface IRequestHandler<TRequest, TResult>
{
    public Task<TResult> HandleAsync(TRequest request);
}