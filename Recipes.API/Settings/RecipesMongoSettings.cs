using Core.MongoDb;

namespace Recipes.API.Settings;

public class RecipesMongoSettings: IMongoSettings
{
    public string Host { get; set; } = null!;
    public string Database { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string RecipesCollectionName { get; set; } = null!;
}