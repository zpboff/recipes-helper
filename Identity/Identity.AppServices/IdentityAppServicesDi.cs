using Identity.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.AppServices;

public static class IdentityAppServicesDi
{
    public static IServiceCollection AddIdentityAppServices(this IServiceCollection services)
    {
        services.AddTransient<IAuthorizedApiProvider, AuthorizedApiProvider>();
        
        return services;
    }
}