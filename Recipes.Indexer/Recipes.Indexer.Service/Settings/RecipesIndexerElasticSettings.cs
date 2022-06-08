using Core.Elastic;

namespace Recipes.Indexer.Service.Settings;

public class RecipesIndexerElasticSettings: IElasticSettings
{
    public string ConnectionString { get; set; }
    public string Index { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}