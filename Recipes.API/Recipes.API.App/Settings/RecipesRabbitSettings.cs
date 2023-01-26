using Core.RabbitMQ;

namespace Recipes.API.App.Settings;

public class RecipesRabbitSettings: IRabbitSettings
{
    public string Host { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}