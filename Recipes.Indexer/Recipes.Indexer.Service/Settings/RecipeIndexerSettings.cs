using Core.Settings;

namespace Recipes.Indexer.Service.Settings;

public class RecipeIndexerSettings: ISettings
{
    public int RetryCount { get; set; }
}