using Elastic.Clients.Elasticsearch;

namespace Core.Elastic;

public interface IElasticClientFactory
{
    ElasticsearchClient GetClient(IElasticSettings settings);
}