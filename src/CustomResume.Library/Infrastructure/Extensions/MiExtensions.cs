using System.Text.Json;

namespace CustomResume.Library.Infrastructure.Extensions;

public static class MiExtensions
{
    public static T? DeserializeWithCamelCase<T>(this string json)
    { 
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        return JsonSerializer.Deserialize<T>(json, options);
    }
    
    public static string Serialize<T>(this T data)
    {
        return JsonSerializer.Serialize(data);
    }
}