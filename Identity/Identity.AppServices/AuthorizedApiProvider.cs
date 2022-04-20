using System.Net.Http.Json;
using System.Text;
using Identity.Contracts;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace Identity.AppServices;

public class AuthorizedApiProvider<TSettings>: IAuthorizedApiProvider<TSettings> where TSettings: IdentitySettings
{
    private readonly TSettings _settings;

    public AuthorizedApiProvider(TSettings settings)
    {
        _settings = settings;
    }
    
    public async Task<T?> GetRequestAsync<T>(string url) where T: class
    {
        return await HandleRequestAsync(async client =>
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
        
            return JsonConvert.DeserializeObject<T>(result);
        }).ConfigureAwait(false);
    }
    
    public async Task<TResponse?> PostRequestAsync<TResponse, TRequest>(string url, TRequest? request = null) 
        where TResponse: class 
        where TRequest: class
    {
        return await HandleRequestAsync(async client =>
        {
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
        
            return JsonConvert.DeserializeObject<TResponse>(result);
        }).ConfigureAwait(false);
    }

    private async Task<TResponse?> HandleRequestAsync<TResponse>(Func<HttpClient, Task<TResponse>> handler)
    {
        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(_settings.IdenityServerUrl);

        var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = "TempClient",
            ClientSecret = "secret",
            Scope = "Recipes.API"
        });

        if (tokenResponse.IsError)
        {
            return await Task.FromException<TResponse?>(tokenResponse.Exception);
        }
        
        client.SetBearerToken(tokenResponse.AccessToken);

        return await handler(client).ConfigureAwait(false);
    }
}