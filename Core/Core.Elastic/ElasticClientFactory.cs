using System.Collections.Concurrent;
using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace Core.Elastic;

public class ElasticClientFactory : IElasticClientFactory
{
    private readonly ConcurrentDictionary<string, ElasticsearchClient> _clients = new();

    public ElasticsearchClient GetClient(IElasticSettings settings)
    {
        if (_clients.TryGetValue(settings.ConnectionString, out var createdClient))
        {
            return createdClient;
        }
        
        var clientSettings = new ElasticsearchClientSettings(new Uri(settings.ConnectionString))
            .Authentication(new BasicAuthentication(settings.User, settings.Password));

        var client = new ElasticsearchClient(clientSettings);

        _clients.TryAdd(settings.ConnectionString, client);

        return client;
    }
}