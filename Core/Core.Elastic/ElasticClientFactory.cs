using Nest;

namespace Core.Elastic;

public class ElasticClientFactory: IElasticClientFactory
{
    public ElasticClient GetClient(string connectionString, string index)
    {
        var settings = new ConnectionSettings(new Uri(connectionString)).DefaultIndex(index);

        return new ElasticClient(settings);
    }
}