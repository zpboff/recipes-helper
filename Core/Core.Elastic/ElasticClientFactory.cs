using Elastic.Clients.Elasticsearch;
using Elastic.Transport;

namespace Core.Elastic;

public class ElasticClientFactory : IElasticClientFactory
{
    public ElasticsearchClient GetClient(IElasticSettings settings)
    {
        var clientSettings = new ElasticsearchClientSettings(new Uri(settings.ConnectionString))
            .Authentication(new BasicAuthentication(settings.User, settings.Password));

        return new ElasticsearchClient(clientSettings);
    }
}