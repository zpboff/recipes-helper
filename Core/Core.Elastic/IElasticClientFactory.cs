using Nest;

namespace Core.Elastic;

public interface IElasticClientFactory
{
    ElasticClient GetClient(string connectionString, string index);
}