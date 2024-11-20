using System.Text.Json.Serialization;
using System.Text.Json;
using JsonHelperLibrary.Extensions;

namespace JsonHelperLibrary;
/// <summary>
/// Provides functionality to convert strings with diacritic characters to their non-diacritic equivalents
/// during JSON serialization and deserialization.
/// </summary>
public class DiacriticsConverter : JsonConverter<string>
{
    public override string Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) 
        => reader.GetString() ?? string.Empty;

    public override void Write(Utf8JsonWriter writer, string value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ReplaceDiacritics2());
    }
}