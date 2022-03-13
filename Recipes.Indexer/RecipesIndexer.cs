using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Entities;
using MassTransit;

namespace Recipes.Indexer;

public class RecipesIndexer: IConsumer<Recipe>
{
    private readonly ILogger<RecipesIndexer> _logger;

    public RecipesIndexer(ILogger<RecipesIndexer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<Recipe> context)
    {
        var recipe = context.Message;
        
        try
        {
            await using Stream stream = File.Create(Path.Combine(Directory.GetCurrentDirectory(), recipe.Id));
            var fileContent = JsonSerializer.Serialize(recipe);
            await stream.WriteAsync(Encoding.UTF8.GetBytes(fileContent));
        }
        catch (Exception e)
        {
            _logger.LogError(e, "RecipesIndexer error");
            throw;
        }
    }
}