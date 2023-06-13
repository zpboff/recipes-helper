using Core.Settings;

namespace BFF.Web.Settings;

public class RecipesApiSettings: ISettings
{
    public string Url { get; set; }
    public string Version { get; set; }
}