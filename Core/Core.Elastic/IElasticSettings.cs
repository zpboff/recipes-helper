using Core.Settings;

namespace Core.Elastic;

public interface IElasticSettings: ISettings
{
    public string ConnectionString { get; set; }
    public string Index { get; set; }
    public string User { get; set; }
    public string Password { get; set; }
}
