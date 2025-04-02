using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DataGridViewCheckBoxApp1.Classes;

#pragma warning disable CS8618
// Author https://colinmackay.scot/tag/system-text-json/


/// <summary>
/// Provides a custom JSON converter for <see cref="decimal"/> values, ensuring consistent formatting and parsing.
/// </summary>
/// <remarks>
/// This converter reads <see cref="decimal"/> values from JSON as strings and parses them using
/// <see cref="CultureInfo.InvariantCulture"/>. When writing, it formats <see cref="decimal"/> values
/// as strings with two decimal places using the same culture.
/// </remarks>
public class FixedDecimalJsonConverter : JsonConverter<decimal>
{
    public override decimal Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        string? stringValue = reader.GetString();
        return string.IsNullOrWhiteSpace(stringValue)
            ? 0
            : decimal.Parse(stringValue, CultureInfo.InvariantCulture);
    }

    public override void Write(Utf8JsonWriter writer, decimal value, JsonSerializerOptions options)
    {
        string numberAsString = value.ToString("F2", CultureInfo.InvariantCulture);
        writer.WriteStringValue(numberAsString);
    }
}