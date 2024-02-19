using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonHelperLibrary;

public class JsonHelpers
{
    public static JsonSerializerOptions CaseInsensitiveOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static readonly JsonSerializerOptions WebOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };
    
    public static JsonSerializerOptions WithWriteIndentOptions = new()
    {
        WriteIndented = true
    };

    public static JsonSerializerOptions WithWriteIndentAndIgnoreReadOnlyPropertiesOptions = new()
    {
        WriteIndented = true, IgnoreReadOnlyProperties = true
    };

    public static JsonSerializerOptions EnumJsonSerializerOptions = new()
    {
        Converters = { new JsonStringEnumConverter() }, 
        WriteIndented = true
    };

    public static JsonSerializerOptions LowerCaseOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase, 
        WriteIndented = true
    };
    public static JsonSerializerOptions ReadStringAsInteger = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    public static List<T>? Deserialize<T>(string json)
        => JsonSerializer.Deserialize<List<T>>(json, WebOptions);

    public class LowerCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToLower();
    }

}