using CommunityToolkit.Diagnostics;
using Namotion.Reflection;

namespace RequestHandlersExample.API.Commands;

public class ValidationMiddleware<TRequest, TResponse> : IRequestMiddlewareHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> HandleAsync(TRequest request, Func<Task<TResponse>> next)
    {
        var name = request.TryGetPropertyValue("Name", "");

        Guard.IsNotNullOrWhiteSpace(name, "Name can not be null or white space!");

        return await next();
    }
}