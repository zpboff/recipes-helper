using Core.Elastic;
using Core.MessageQueue.Public;
using Recipes.API.Models.Shared.Messages;
using Recipes.Indexer.Models;
using Recipes.Indexer.Service.Settings;

namespace Recipes.Indexer.Service;

public class RecipesIndexer : BackgroundService
{
    private readonly ILogger<RecipesIndexer> _logger;
    private readonly IElasticClientFactory _clientFactory;
    private readonly RecipesIndexerElasticSettings _settings;
    private readonly IMessageConsumer _consumer;
    private readonly RecipesIndexerMessageQueueSettings _queueSettings;

    public RecipesIndexer(ILogger<RecipesIndexer> logger, IElasticClientFactory clientFactory,
        RecipesIndexerElasticSettings settings, IMessageConsumer consumer,
        RecipesIndexerMessageQueueSettings queueSettings)
    {
        _logger = logger;
        _clientFactory = clientFactory;
        _settings = settings;
        _consumer = consumer;
        _queueSettings = queueSettings;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _consumer.OnMessage<RecipeMessage>(_queueSettings, nameof(RecipesIndexer), OnMessage);

        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            await Task.Delay(1000, stoppingToken);
        }
    }

    private async Task OnMessage(RecipeMessage message)
    {
        var client = _clientFactory.GetClient(_settings);

        var indexExistsResponse = await client.Indices.ExistsAsync(_settings.Index);

        if (!indexExistsResponse.Exists)
        {
            await client.Indices.CreateAsync(_settings.Index, crd => { crd.Mappings(crm => { crm.Enabled(); }); });

            _logger.LogInformation("Index created: {0}", _settings.Index);
        }

        var document = RecipeDocument.FromRecipe(message.Recipe);

        await client.IndexAsync(document, _settings.Index);

        _logger.LogInformation("Recipe indexed: {0}", document.Id);
    }
}