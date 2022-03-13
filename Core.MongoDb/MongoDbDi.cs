using Microsoft.Extensions.DependencyInjection;

namespace Core.MongoDb;

public static class MongoDbDi
{
    public static IServiceCollection RegisterMongoDb(this IServiceCollection services)
    {
        services.AddTransient<IMongoFactory, MongoFactory>();
        
        return services;
    }
}