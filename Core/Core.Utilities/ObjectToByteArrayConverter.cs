using System.Text;
using System.Text.Json;

namespace Core.Utilities;

public static class ObjectToByteArrayConverter
{
    public static byte[] Convert<T>(T obj) where T: class, new()
    {
        var json = JsonSerializer.Serialize(obj);

        return Encoding.UTF8.GetBytes(json);
    }
}