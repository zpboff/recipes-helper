using Core.MongoDb;

namespace Recipes.API.Settings;

public class RecipesMongoSettings: IMongoSettings
{
    public string ConnectionString { get; set; } = null!;
    public string Database { get; set; } = null!;
    public string RecipesCollectionName { get; set; } = null!;
}