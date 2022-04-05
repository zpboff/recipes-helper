using Core.MongoDb;

namespace Auth.Settings;

public class AuthMongoSettings: IMongoSettings
{
    public string ConnectionString { get; set; } = null!;
    public string Database { get; set; } = null!;
    public string IdentityResourcesCollectionName { get; set; } = null!;
    public string ApiScopesCollectionName { get; set; } = null!;
    public string ApiResourcesCollectionName { get; set; } = null!;
    public string ClientsCollectionName { get; set; } = null!;
    public string GrantsCollectionName { get; set; } = null!;
    
}