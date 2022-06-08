using Identity.Contracts;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.AppServices;

public static class IdentityAppServicesDi
{
    public static IServiceCollection AddIdentityAppServices<TSettings>(this IServiceCollection services)
        where TSettings : IdentitySettings
    {
        services.AddTransient<IAuthorizedApiProvider<TSettings>, AuthorizedApiProvider<TSettings>>();

        return services;
    }
}