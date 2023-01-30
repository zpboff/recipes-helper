using Microsoft.Extensions.DependencyInjection;

namespace Core.SqlDb;

public static class SqlDbDi
{
    public static IServiceCollection RegisterSqlDb(this IServiceCollection services)
    {
        services.AddTransient<ISqlConnectionFactory, SqlConnectionFactory>();
        
        return services;
    }
}