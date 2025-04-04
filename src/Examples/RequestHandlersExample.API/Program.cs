var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Logging.ClearProviders();

builder.Services.AddMediator();
builder.Services.AddRequestHandlers(typeof(Program).Assembly);
// OR
// builder.Services.AddTransientRequestHandler<SayHelloCommand, SayHelloCommandHandler, string>();
// OR
// builder.Services.AddSingletonRequestHandler<SayHelloCommand, SayHelloCommandHandler, string>();
// OR
// builder.Services.AddScopedRequestHandler<SayHelloCommand, SayHelloCommandHandler, string>();
builder.Services.AddTransientDefaultRequestMiddlewareHandler(typeof(LoggingMiddleware<,>));
builder.Services.AddTransientDefaultRequestMiddlewareHandler(typeof(ValidationMiddleware<,>));

builder.Services.AddAPIDefaultServices();

builder.Services.AddLogging(builder => builder.AddJsonLogger(opt =>
{
    opt.MinimumLogLevel = LogLevel.Debug;
}));

var app = builder.Build();

app.MapAPIEndpoints(typeof(Program).Assembly);
app.UseOpenApi();
app.UseSwaggerUi();

var httpContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();

var logger = app.Services.GetRequiredService<ILogger<Program>>();

app.SetJsonLoggerHttpContextAccessor();

app.Run();