using Core.Settings;

namespace Core.MongoDb;

public interface IMongoSettings: ISettings
{
    public string Host { get; set; }
    public string Database { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}