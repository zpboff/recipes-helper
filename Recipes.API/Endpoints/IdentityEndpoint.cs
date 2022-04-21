using FastEndpoints;
using Serilog;

namespace Recipes.API.Endpoints;

public class IdentityEndpoint: Endpoint<object>
{
    public override void Configure()
    {
        Get();
        Routes("/identity");
        AllowAnonymous();
    }

    public override async Task HandleAsync(object req, CancellationToken ct)
    {
        Log.Logger.Debug("12312312");
        await SendAsync(new 
        {   
            claims = User.Claims.Select(c => c.Type)
        }, cancellation: ct);
    }
}