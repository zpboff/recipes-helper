using Nest;

namespace Core.Elastic;

public class ElasticClientFactory : IElasticClientFactory
{
    public ElasticClient GetClient(IElasticSettings settings)
    {
        var connectionSettings = new ConnectionSettings(new Uri(settings.ConnectionString))
            .DefaultIndex(settings.Index)
            .BasicAuthentication(settings.User, settings.Password);

        return new ElasticClient(connectionSettings);
    }
}