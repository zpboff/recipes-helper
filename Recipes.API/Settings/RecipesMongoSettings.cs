using Core.MongoDb;

namespace Recipes.API.Settings;

public class RecipesMongoSettings: IMongoSettings
{
    public string ConnectionString { get; set; }
    public string Database { get; set; }
    public string CollectionName { get; set; }
}