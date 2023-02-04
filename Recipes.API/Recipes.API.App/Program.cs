using System.Reflection;
using Core.Logging;
using Core.MessageBus.RabbitMQ;
using Core.MongoDb;
using Core.Settings;
using FluentValidation;
using Recipes.API.App;
using Recipes.API.App.Services;
using Recipes.API.App.Validators;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseSentry();
builder.Host.UseSerilog();

builder.Services
    .RegisterInternalServices()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddMongoDb()
    .AddRabbitMq()
    .RegisterConfiguration(builder.Configuration)
    .AddSerilogLogging(builder.Configuration)
    .AddHttpClient()
    .AddControllers();

builder.Services
    .AddTransient<CreateRecipeService>()
    .AddTransient<UpdateRecipeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
    
app.UseRouting();
app.UseSentryTracing();

app.UseAuthentication();
app.UseAuthorization();

app.UseSerilogRequestLogging();
app.MapControllers();

app.Run();