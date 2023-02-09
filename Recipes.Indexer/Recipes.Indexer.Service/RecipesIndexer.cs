using Core.Elastic;
using Core.MessageBus.Public;
using Recipes.API.Models.Shared;
using Recipes.Indexer.Service.Settings;
using Recipes.Indexer.Shared;

namespace Recipes.Indexer.Service;

public class RecipesIndexer : BackgroundService
{
    private readonly ILogger<RecipesIndexer> _logger;
    private readonly IElasticClientFactory _clientFactory;
    private readonly RecipesIndexerElasticSettings _settings;
    private readonly IMessageConsumer _consumer;

    public RecipesIndexer(ILogger<RecipesIndexer> logger, IElasticClientFactory clientFactory,
        RecipesIndexerElasticSettings settings, IMessageConsumer consumer,
        RecipesIndexerMessageBusSettings busSettings)
    {
        _logger = logger;
        _clientFactory = clientFactory;
        _settings = settings;
        _consumer = consumer.Initialize(busSettings);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        try
        {
            _consumer.OnMessage<RecipeReadDto>(nameof(RecipesIndexer), OnMessage);

            while (!stoppingToken.IsCancellationRequested)
            {
                await Task.Delay(1000, stoppingToken);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        finally
        {
            _consumer.Dispose();
        }
    }

    private async Task OnMessage(RecipeReadDto message)
    {
        var client = _clientFactory.GetClient(_settings);

        var indexExistsResponse = await client.Indices.ExistsAsync(_settings.Index);

        if (!indexExistsResponse.Exists)
        {
            await client.Indices.CreateAsync(_settings.Index, crd => { crd.Mappings(crm => { crm.Enabled(); }); });

            _logger.LogInformation("Index created: {0}", _settings.Index);
        }

        var document = RecipeDocument.FromRecipeReadDto(message);

        await client.IndexAsync(document, _settings.Index);

        _logger.LogInformation("Recipe indexed: {0}", document.Id);
    }
}