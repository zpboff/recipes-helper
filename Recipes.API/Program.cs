global using FastEndpoints;
global using FastEndpoints.Validation;
using Core.MongoDb;
using Core.Settings;
using Recipes.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddFastEndpoints();
builder.Services
    .RegisterMongoDb()
    .RegisterConfiguration(builder.Configuration);

builder.Services.AddTransient<CreateRecipeService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseFastEndpoints();

app.Run();