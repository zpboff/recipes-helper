using Npgsql;

namespace Core.SqlDb;

public interface ISqlConnectionFactory
{
    Task<NpgsqlConnection> CreateConnectionAsync();
}