using MongoDB.Driver;

namespace Core.MongoDb;

public class MongoFactory: IMongoFactory
{
    public IMongoDatabase GetDataBase(IMongoSettings settings)
    {
        var credentials = string.IsNullOrEmpty(settings.User)
            ? string.Empty
            : $"{settings.User}:{settings.Password}@";
        
        var client = new MongoClient($"mongodb://{credentials}{settings.Host}");

        return client.GetDatabase(settings.Database);
    }
}