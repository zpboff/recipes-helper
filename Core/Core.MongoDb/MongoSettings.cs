namespace Core.MongoDb;

public class MongoSettings: IMongoSettings
{
    public string Host { get; set; } = null!;
    public string Database { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}