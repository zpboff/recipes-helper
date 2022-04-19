using Core.MongoDb;
using Core.RabbitMQ;
using Core.Settings;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Recipes.API.Services;
using Recipes.API.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddFastEndpoints()
    .AddMongoDb()
    .AddRabbit<RecipesRabbitSettings>()
    .RegisterConfiguration(builder.Configuration)
    .AddControllers();

builder.Services.AddTransient<CreateRecipeService>();
builder.Services
    .AddAuthorization()
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

app.UseAuthentication();
app.UseAuthorization();

app.UseFastEndpoints();

app.Run();