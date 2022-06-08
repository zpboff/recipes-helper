using Core.Settings;

namespace Identity.Contracts;

public class IdentitySettings: ISettings
{
    public string IdenityServerUrl { get; set; } = null!;
}