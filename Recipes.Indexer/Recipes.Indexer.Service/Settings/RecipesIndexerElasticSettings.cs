using Core.Elastic;

namespace Recipes.Indexer.Service.Settings;

public class RecipesIndexerElasticSettings: IElasticSettings
{
    public string ConnectionString { get; set; } = null!;
    public string Index { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}