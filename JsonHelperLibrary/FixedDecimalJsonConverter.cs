using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonHelperLibrary;

#pragma warning disable CS8618

/// <summary>
/// Write decimal as two places as a string
/// </summary>
/// <remarks>
/// Requires the following to return as a decimal
/// <code>
/// JsonSerializerOptions jsonOptions = new()
/// {
///    NumberHandling = JsonNumberHandling.AllowReadingFromString
/// }
///
/// JsonHelpers.Deserialize&lt;List{T}>(File.ReadAllText(_fileName), jsonOptions);
/// 
/// </code>
/// </remarks>
public class FixedDecimalJsonConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var stringValue = reader.GetString();
        return string.IsNullOrWhiteSpace(stringValue)
            ? default
            : decimal.Parse(stringValue, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        var numberAsString = value.ToString("F2", CultureInfo.InvariantCulture);
        writer.WriteStringValue(numberAsString);
    }
}