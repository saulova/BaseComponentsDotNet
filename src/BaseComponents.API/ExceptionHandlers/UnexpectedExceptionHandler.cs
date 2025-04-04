namespace BaseComponents.API.ExceptionHandlers;

internal sealed class UnexpectedExceptionHandler : IExceptionHandler
{
    private readonly ILogger<UnexpectedExceptionHandler> _logger;

    public UnexpectedExceptionHandler(ILogger<UnexpectedExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.Error($"Unexpected exception occurred: {exception.Message}", exception);

        var problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal Server error"
        };

        httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }
}