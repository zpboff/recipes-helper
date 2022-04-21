using Core.RabbitMQ;

namespace Recipes.Indexer.Service.Settings;

public class RecipesIndexerRabbitSettings: RabbitSettings
{
    public string QueueName { get; set; } = null!;
}