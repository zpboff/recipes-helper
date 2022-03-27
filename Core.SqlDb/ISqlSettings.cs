using Core.Settings;

namespace Core.SqlDb;

public interface ISqlSettings: ISettings
{
    public string ConnectionString { get; set; }
}