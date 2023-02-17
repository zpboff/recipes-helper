using Core.Logging;
using Core.Settings;
using Recipes.Search.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseConfiguration()
    .UseLogging();

builder.Services
    .AddServices(builder.Configuration)
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();