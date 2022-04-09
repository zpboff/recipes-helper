using FastEndpoints;

namespace Recipes.API.Endpoints;

public class IdentityEndpoint: Endpoint<object>
{
    public override void Configure()
    {
        Post();
        Routes("/identity");
    }

    public override async Task HandleAsync(object req, CancellationToken ct)
    {
        await SendAsync(new 
        {   
            claims = User.Claims
        }, cancellation: ct);
    }
}