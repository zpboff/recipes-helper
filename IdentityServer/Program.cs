using Core.Settings;
using IdentityServer.Models;
using IdentityServer.Settings;

var builder = WebApplication.CreateBuilder(args);

var mongoSettings = builder.Configuration.GetSection(nameof(IdentityMongoSettings)).Get<IdentityMongoSettings>();

builder.Services
    .RegisterConfiguration(builder.Configuration)
    .AddIdentity<ApplicationUser, ApplicationRole>()
    .AddMongoDbStores<ApplicationUser, ApplicationRole, string>(
        $"mongodb://{mongoSettings.User}:{mongoSettings.Password}@{mongoSettings.Host}",
        mongoSettings.Database
    );

builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();