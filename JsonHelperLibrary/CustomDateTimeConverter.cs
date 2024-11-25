using System.Text.Json.Serialization;
using System.Text.Json;
using System.Globalization;

namespace JsonHelperLibrary;
/// <summary>
/// Provides custom JSON serialization and deserialization for <see cref="DateTime"/> objects.
/// This converter handles <see cref="DateTime"/> values formatted as "yyyy-MM-dd HH:mm:ss".
/// </summary>
public class CustomDateTimeConverter : JsonConverter<DateTime?>
{
    private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

    /// <summary>
    /// Reads and converts the JSON to a nullable <see cref="DateTime"/> object.
    /// </summary>
    /// <param name="reader">The <see cref="Utf8JsonReader"/> to read from.</param>
    /// <param name="typeToConvert">The type to convert the JSON to.</param>
    /// <param name="options">Options to control the conversion behavior.</param>
    /// <returns>A nullable <see cref="DateTime"/> object if the conversion is successful; otherwise, <c>null</c>.</returns>
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String) return null;
        if (DateTime.TryParseExact(reader.GetString(), DateTimeFormat, null, DateTimeStyles.None, out var dateTime))
        {
            return dateTime;
        }

        return null;

    }

    /// <summary>
    /// Writes a nullable <see cref="DateTime"/> object as a JSON string.
    /// </summary>
    /// <param name="writer">The <see cref="Utf8JsonWriter"/> to write to.</param>
    /// <param name="value">The nullable <see cref="DateTime"/> value to write.</param>
    /// <param name="options">Options to control the conversion behavior.</param>
    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString(DateTimeFormat));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}