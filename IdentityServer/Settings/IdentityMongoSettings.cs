using Core.MongoDb;

namespace IdentityServer.Settings;

public class IdentityMongoSettings: MongoSettings
{
    public string IdentityCollectionName { get; set; } = null!;
}