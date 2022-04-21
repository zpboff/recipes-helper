using Core.Elastic;
using MapsterMapper;
using MassTransit;
using Recipes.API.Models.Shared.Messages;
using Recipes.Indexer.Models;
using Recipes.Indexer.Service.Settings;

namespace Recipes.Indexer.Service;

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
            var client = _clientFactory.GetClient(_settings);

            var indexExistsResponse = await client.Indices.ExistsAsync(_settings.Index);

            if (!indexExistsResponse.Exists)
            {
                await client.Indices.CreateAsync(_settings.Index, crd =>
                {
                    crd.Mappings(crm =>
                    {
                        crm.Enabled();
                    });
                });
            }
            
            await client.IndexAsync(document, _settings.Index);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "RecipesIndexer error");
            throw;
        }
    }
}