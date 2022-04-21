using Duende.Bff.Yarp;
using IdentityModel;
using Serilog;

namespace Web.BFF;

internal static class HostingExtensions
{
    public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddRazorPages();

        builder.Services.AddControllers();

        builder.Services.AddBff()
            .AddRemoteApis()
            .AddServerSideSessions();

        builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = "cookie";
                options.DefaultChallengeScheme = "oidc";
                options.DefaultSignOutScheme = "oidc";
            })
            .AddCookie("cookie", options =>
            {
                options.Cookie.Name = "__Host-bff";
                options.Cookie.SameSite = SameSiteMode.Strict;
            })
            .AddOpenIdConnect("oidc", options =>
            {
                options.Authority = "https://localhost:7001";
                options.ClientId = "Web.BFF";
                options.ClientSecret = "Web.BFF";
                options.ResponseType = OidcConstants.ResponseTypes.Code;
                options.ResponseMode = OidcConstants.ResponseModes.Query;

                options.GetClaimsFromUserInfoEndpoint = true;
                options.SaveTokens = true;
                options.MapInboundClaims = false;

                options.Scope.Clear();
                options.Scope.Add(OidcConstants.StandardScopes.OpenId);
                options.Scope.Add(OidcConstants.StandardScopes.Profile);
                options.Scope.Add("api");
                options.Scope.Add(OidcConstants.StandardScopes.OpenId);

                options.TokenValidationParameters.NameClaimType = "name";
                options.TokenValidationParameters.RoleClaimType = "role";
            });

        return builder.Build();
    }

    public static WebApplication ConfigurePipeline(this WebApplication app)
    {
        app.UseSerilogRequestLogging();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseDefaultFiles();
        app.UseStaticFiles();
        app.UseAuthentication();
        app.UseRouting();

        app.UseBff();
        app.UseAuthorization();

        app.MapControllers()
            .RequireAuthorization()
            .AsBffApiEndpoint();

        app.MapBffManagementEndpoints();

        app.MapRemoteBffApiEndpoint("/remote", "https://demo.duendesoftware.com/api/test")
            .RequireAccessToken();

        return app;
    }
}