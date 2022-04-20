using Core.Settings;

namespace TempClient;

public class TempClientSettings: ISettings
{
    public string IdentityServerUrl { get; set; } = null!;
    public string ApiUrl { get; set; } = null!;
}