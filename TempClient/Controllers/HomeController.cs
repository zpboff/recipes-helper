using Identity.Contracts;
using Microsoft.AspNetCore.Mvc;
using Recipes.API.Models.CreateRecipe;

namespace TempClient.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    private readonly IAuthorizedApiProvider _apiProvider;
    private readonly TempClientSettings _settings;
    
    public HomeController(IAuthorizedApiProvider apiProvider, TempClientSettings settings)
    {
        _apiProvider = apiProvider;
        _settings = settings;
    }

    [Route("[action]")]
    public async Task Get()
    {
        await _apiProvider.GetRequestAsync<object>(_settings.IdentityServerUrl, $"{_settings.ApiUrl}/identity");
    }
}