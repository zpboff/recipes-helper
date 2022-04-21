using Core.Elastic;

namespace Recipes.Search.Api.Settings;

public class RecipesElasticSettings: IElasticSettings
{
    public string ConnectionString { get; set; } = null!;
    public string Index { get; set; } = null!;
    public string User { get; set; } = null!;
    public string Password { get; set; } = null!;
}