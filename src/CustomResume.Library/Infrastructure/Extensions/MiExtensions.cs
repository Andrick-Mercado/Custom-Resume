using System.Text.Json;

namespace CustomResume.Library.Infrastructure.Extensions;

public static class MiExtensions
{
    private static readonly JsonSerializerOptions CamelCaseOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    public static T DeserializeWithCamelCase<T>(this string json) => JsonSerializer.Deserialize<T>(json, CamelCaseOptions);

    public static string Serialize<T>(this T data) => JsonSerializer.Serialize(data);
}