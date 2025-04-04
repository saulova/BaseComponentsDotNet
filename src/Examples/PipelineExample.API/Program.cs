var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProblemDetails();
builder.Logging.ClearProviders();

builder.Services.AddMediator();
builder.Services.AddTransientPipelineOperation<HelloPipelineContext, AppendHelloOperation>();
builder.Services.AddTransientPipelineOperation<HelloPipelineContext, AppendNameOperation>();

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