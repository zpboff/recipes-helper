using Core.Logging;
using Core.MongoDb;
using Core.RabbitMQ;
using Core.Settings;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Recipes.API.App.Services;
using Recipes.API.App.Settings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseSentry();
builder.Host.UseSerilog();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddFastEndpoints()
    .AddMongoDb()
    .AddRabbit<RecipesRabbitSettings>()
    .RegisterConfiguration(builder.Configuration)
    .AddLogging(builder.Configuration)
    .AddHttpClient()
    .AddControllers();

builder.Services.AddTransient<CreateRecipeService>();
builder.Services
    .AddAuthorization(options =>
    {
        options.AddPolicy("ApiScope", policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.RequireClaim("scope", "Recipes.API.App");
        });
    })
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = builder.Configuration.GetConnectionString("IdentityServerUrl");

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false
        };
    });

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

app.UseFastEndpoints();
app.UseSerilogRequestLogging();

app.Run();