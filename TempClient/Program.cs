using Core.Settings;
using Identity.AppServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .RegisterConfiguration(builder.Configuration)
    .AddIdentityAppServices()
    .AddEndpointsApiExplorer()
    .AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();