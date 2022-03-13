using Core.RabbitMQ;

namespace Recipes.Indexer.Settings;

public class RecipesIndexerRabbitSettings: RabbitSettings
{
    public string QueueName { get; set; } = null!;
}