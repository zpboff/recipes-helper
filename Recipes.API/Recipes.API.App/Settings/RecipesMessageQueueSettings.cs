using Core.MessageQueue.Public;
using Core.MessageQueue.RabbitMQ;

namespace Recipes.API.App.Settings;

public class RecipesMessageQueueSettings: IMessageQueueSettings
{
    public string Host { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}