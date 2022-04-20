using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Identity.Contracts;
using IdentityModel.Client;
using Newtonsoft.Json;

namespace Identity.AppServices;

public class AuthorizedApiProvider: IAuthorizedApiProvider
{
    public async Task<T?> GetRequestAsync<T>(string identityServerUrl, string url) where T: class
    {
        return await HandleRequestAsync(identityServerUrl, async client =>
        {
            var response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
        
            return JsonConvert.DeserializeObject<T>(result);
        });
    }
    
    public async Task<TResponse?> PostRequestAsync<TResponse, TRequest>(string identityServerUrl, string url, TRequest? request = null) 
        where TResponse: class 
        where TRequest: class
    {
        return await HandleRequestAsync(identityServerUrl, async client =>
        {
            var json = JsonConvert.SerializeObject(request);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            
            var response = await client.PostAsJsonAsync(url, data);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
        
            return JsonConvert.DeserializeObject<TResponse>(result);
        });
    }

    private async Task<TResponse?> HandleRequestAsync<TResponse>(string identityServerUrl, Func<HttpClient, Task<TResponse>> handler)
    {
        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(identityServerUrl);

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

        return await handler(client);
    }
}