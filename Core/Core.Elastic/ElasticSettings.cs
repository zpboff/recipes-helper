using Core.Settings;

namespace Core.Elastic;

public class ElasticSettings: ISettings
{
    public string ConnectionString { get; set; }
    public string Index { get; set; }
}
