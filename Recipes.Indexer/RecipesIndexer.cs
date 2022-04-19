using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Entities;
using Entities.Recipe;
using MassTransit;
using Messages;

namespace Recipes.Indexer;

public class RecipesIndexer: IConsumer<RecipeMessage>
{
    private readonly ILogger<RecipesIndexer> _logger;

    public RecipesIndexer(ILogger<RecipesIndexer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<RecipeMessage> context)
    {
        var recipe = context.Message.Recipe;
        
        try
        {
            
        }
        catch (Exception e)
        {
            _logger.LogError(e, "RecipesIndexer error");
            throw;
        }
    }
}