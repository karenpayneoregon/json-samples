using System.Text.Json;

namespace JsonHelperLibrary;

public static class DeserializeExtensions
{
    private static JsonSerializerOptions? defaultSerializerSettings = new();
    private static JsonSerializerOptions? featureXSerializerSettings = new();
    public static T? Deserialize<T>(this string json) 
        => JsonSerializer.Deserialize<T>(json, defaultSerializerSettings);
    public static T? DeserializeCustom<T>(this string json, JsonSerializerOptions? settings) 
        => JsonSerializer.Deserialize<T>(json, settings);
    public static T? DeserializeFeatureX<T>(this string json) 
        => JsonSerializer.Deserialize<T>(json, featureXSerializerSettings);
}