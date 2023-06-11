using Microsoft.OpenApi.Models;
using Workshop.Notes.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IStore<Workshop.Notes.WebApi.Models.Note>, InMemoryStore<Workshop.Notes.WebApi.Models.Note>>();
builder.Services.AddSingleton<IStore<Workshop.Notes.WebApi.Models.Task>, InMemoryStore<Workshop.Notes.WebApi.Models.Task>>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

builder.Services.AddHealthChecks();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Notes API",
        Description = "An ASP.NET Core Web API for managing Notes",
    });
});

var app = builder.Build();

app.UseWelcomePage("/");

app.UseAuthorization();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHealthChecks("/health");

app.MapControllers();

app.Run();
