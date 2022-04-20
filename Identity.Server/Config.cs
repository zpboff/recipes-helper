using Duende.IdentityServer.Models;

namespace Identity.Server;

public static class Config
{
    public static IEnumerable<IdentityResource> IdentityResources =>
        new IdentityResource[]
        { 
            new IdentityResources.OpenId()
        };

    public static IEnumerable<ApiScope> ApiScopes =>
        new []
        {
            new ApiScope(name: "Recipes.API", displayName: "Recipes.API") 
        };

    public static IEnumerable<Client> Clients =>
        new []
        {
            new Client
            {
                ClientId = "TempClient",
                AllowedGrantTypes = GrantTypes.ClientCredentials,
                ClientSecrets =
                {
                    new Secret("secret".Sha256())
                },
                AllowedScopes =
                {
                    "Recipes.API"
                }
            }
        };
}