using Microsoft.OpenApi.Models;
using Workshop.Notes.WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<INoteStore, InMemoryNoteStore>();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
});

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

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
