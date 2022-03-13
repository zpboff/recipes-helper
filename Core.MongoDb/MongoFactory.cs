using MongoDB.Driver;

namespace Core.MongoDb;

public class MongoFactory: IMongoFactory
{
    public IMongoDatabase GetDataBase(string connectionString, string dataBase)
    {
        var client = new MongoClient(connectionString);

        return client.GetDatabase(dataBase);
    }
}