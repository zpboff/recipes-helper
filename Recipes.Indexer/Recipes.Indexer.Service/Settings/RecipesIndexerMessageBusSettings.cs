using Core.MessageBus.Public;

namespace Recipes.Indexer.Service.Settings;

public class RecipesIndexerMessageBusSettings: IMessageBusSettings
{
    public string Host { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}