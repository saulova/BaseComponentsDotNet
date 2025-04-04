var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Logging.ClearProviders();

builder.Services.AddMediator();
builder.Services.AddEventHandlers(typeof(Program).Assembly);
// OR
// builder.Services.AddTransientEventHandler<SayHelloEvent, SayHelloEventHandler>();
// OR
// builder.Services.AddSingletonEventHandler<SayHelloEvent, SayHelloEventHandler>();
// OR
// builder.Services.AddScopedEventHandler<SayHelloEvent, SayHelloEventHandler>();
builder.Services.AddTransientDefaultEventMiddlewareHandler(typeof(EventLoggingMiddleware<>));
builder.Services.AddTransientDefaultEventMiddlewareHandler(typeof(EventValidationMiddleware<>));

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