using Core.Elastic;
using Mapster;
using MapsterMapper;
using MassTransit;
using Messages;
using Nest;
using Recipes.Indexer.Models;
using Recipes.Indexer.Settings;

namespace Recipes.Indexer;

public class RecipesIndexer : IConsumer<RecipeMessage>
{
    private readonly ILogger<RecipesIndexer> _logger;
    private readonly IElasticClientFactory _clientFactory;
    private readonly RecipesIndexerElasticSettings _settings;
    private readonly IMapper _mapper;

    public RecipesIndexer(ILogger<RecipesIndexer> logger, IElasticClientFactory clientFactory,
        RecipesIndexerElasticSettings settings, IMapper mapper)
    {
        _logger = logger;
        _clientFactory = clientFactory;
        _settings = settings;
        _mapper = mapper;
    }

    public async Task Consume(ConsumeContext<RecipeMessage> context)
    {
        var recipe = context.Message.Recipe;

        try
        {
            var document = _mapper.Map<RecipeDocument>(recipe);
            var client = _clientFactory.GetClient(_settings.ConnectionString, _settings.Index);

            var indexExistsResponse = await client.Indices.ExistsAsync(_settings.Index);

            if (!indexExistsResponse.Exists)
            {
                await client.Indices.CreateAsync(_settings.Index, c => c.Map<RecipeDocument>(d => d.AutoMap<RecipeDocument>()));
            }
            
            await client.IndexDocumentAsync(document);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "RecipesIndexer error");
            throw;
        }
    }
}