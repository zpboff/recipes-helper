using MongoDB.Driver;

namespace Core.MongoDb;

public class MongoFactory: IMongoFactory
{
    public IMongoDatabase GetDataBase(IMongoSettings settings)
    {
        var client = new MongoClient($"mongodb://{settings.User}:{settings.Password}@{settings.Host}");

        return client.GetDatabase(settings.Database);
    }
}