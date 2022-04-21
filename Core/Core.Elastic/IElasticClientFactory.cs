using Nest;

namespace Core.Elastic;

public interface IElasticClientFactory
{
    ElasticClient GetClient(IElasticSettings settings);
}