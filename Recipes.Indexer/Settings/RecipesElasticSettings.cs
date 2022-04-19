using Core.Settings;

namespace Recipes.Indexer.Settings;

public class RecipesElasticSettings: ISettings
{
    public string ConnectionString { get; set; }
}