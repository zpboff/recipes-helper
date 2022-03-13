using MongoDB.Driver;

namespace Core.MongoDb;

public interface IMongoFactory
{
    IMongoDatabase GetDataBase(string connectionString, string dataBase);
}