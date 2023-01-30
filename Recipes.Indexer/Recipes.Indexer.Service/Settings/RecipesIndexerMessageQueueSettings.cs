using Core.MessageQueue.Public;
using Core.MessageQueue.RabbitMQ;

namespace Recipes.Indexer.Service.Settings;

public class RecipesIndexerMessageQueueSettings: IMessageQueueSettings
{
    public string QueueName { get; set; } = null!;
    public string Host { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}