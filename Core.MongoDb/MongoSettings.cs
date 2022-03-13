using Core.Settings;

namespace Core.MongoDb;

public interface IMongoSettings: ISettings
{
    public string ConnectionString { get; set; }
    public string Database { get; set; }
}