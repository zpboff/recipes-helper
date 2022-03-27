using Microsoft.Extensions.DependencyInjection;

namespace Core.SqlDb;

public static class MongoDbDi
{
    public static IServiceCollection RegisterMongoDb(this IServiceCollection services)
    {
        services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();
        
        return services;
    }
}