using MongoDB.Driver;

namespace Core.MongoDb;

public interface IMongoFactory
{
    IMongoDatabase GetDataBase(IMongoSettings settings);
}