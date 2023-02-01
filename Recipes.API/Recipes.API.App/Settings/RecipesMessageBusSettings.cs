using Core.MessageBus.Public;

namespace Recipes.API.App.Settings;

public class RecipesMessageBusSettings: IMessageBusSettings
{
    public string Host { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}