using System.Text.Json;
using BFF.Web.Settings;
using Recipes.API.Models.Shared;

namespace BFF.Web.Providers;

public class RecipesSearchProvider: IRecipesSearchProvider
{
    private readonly RecipesApiSettings _settings;

    public RecipesSearchProvider(RecipesApiSettings settings)
    {
        _settings = settings;
    }

    public async Task<IEnumerable<RecipeReadDto>?> Search(string query)
    {
        return new[]
        {
            new RecipeReadDto
            {
                Id = Guid.NewGuid().ToString(),
                Description = "Test description",
                Title = "Test title"
            }
        };
        
        var httClient = new HttpClient();
        var uri = new Uri($"{_settings.Url}/api/{_settings.Version}/Search/{query}");
        var res = await httClient.GetAsync(uri);

        var json = await res.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<IEnumerable<RecipeReadDto>>(json);
    }
}