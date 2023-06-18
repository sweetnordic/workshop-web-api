using Microsoft.OpenApi.Models;
using Workshop.Notes.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IStore<Workshop.Notes.WebApi.Models.Note>, InMemoryStore<Workshop.Notes.WebApi.Models.Note>>();
builder.Services.AddSingleton<IStore<Workshop.Notes.WebApi.Models.Task>, InMemoryStore<Workshop.Notes.WebApi.Models.Task>>();

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNameCaseInsensitive = true);
// builder.Services.AddApplicationInsightsTelemetry(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHealthChecks();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Web API",
        Description = "An ASP.NET Core Web API for managing Notes and Tasks.",
    });
});

var app = builder.Build();

app.UseWelcomePage("/");

app.UseAuthorization();

app.UseSwagger(setup =>
{
    setup.SerializeAsV2 = false;
    setup.RouteTemplate = "/api/{documentName}.json";
});
app.UseSwaggerUI(setup =>
{
    setup.DocumentTitle = "Web API Playground";
    setup.SwaggerEndpoint("/api/v1.json", "API Template v1");
    setup.RoutePrefix = "swagger";
});
app.UseHealthChecks("/health");

// app.UseCors(policy =>
// {
//     policy.AllowAnyOrigin();
//     policy.AllowAnyHeader();
//     policy.AllowAnyMethod();
// });

app.MapControllers();

app.Run();
