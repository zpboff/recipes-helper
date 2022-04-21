using Core.RabbitMQ;

namespace Recipes.Indexer.Service.Settings;

public class RecipesIndexerRabbitSettings: IRabbitSettings
{
    public string QueueName { get; set; } = null!;
    public string Host { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}