using Core.Logging;
using Core.MessageBus.RabbitMQ;
using Core.MongoDb;
using Core.Settings;
using Recipes.API.App;
using Recipes.API.App.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseSentry();
builder.Host
    .UseConfiguration()
    .UseLogging();

builder.Services
    .RegisterInternalServices()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddMongoDb()
    .AddRabbitMq()
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

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
    
app.UseRouting();
app.UseSentryTracing();

app.UseAuthentication();
app.UseAuthorization();

app.UseSerilogRequestLogging();
app.MapControllers();

app.Run();