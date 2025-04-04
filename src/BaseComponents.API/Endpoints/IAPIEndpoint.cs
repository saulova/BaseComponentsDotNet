namespace BaseComponents.API.Endpoints;

public interface IAPIEndpoint {
    public static abstract void Configure(IEndpointRouteBuilder app);
    
	public static abstract Task<IResult> HandleAsync(HttpContext httpContext, CancellationToken cancellationToken);
}

public interface IAPIEndpoint<TRequest> where TRequest : notnull
{
    public static abstract void Configure(IEndpointRouteBuilder app);
    
	public static abstract Task<IResult> HandleAsync(TRequest request, CancellationToken cancellationToken);
}

public interface IAPIEndpoint<TRequest, TServices> where TRequest : notnull where TServices : notnull 
{
    public static abstract void Configure(IEndpointRouteBuilder app);
    
	public static abstract Task<IResult> HandleAsync(TRequest request, TServices services, CancellationToken cancellationToken);
}