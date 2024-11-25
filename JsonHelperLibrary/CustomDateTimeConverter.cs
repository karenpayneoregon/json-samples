using System.Text.Json.Serialization;
using System.Text.Json;

namespace JsonHelperLibrary;
/// <summary>
/// Provides custom JSON serialization and deserialization for <see cref="DateTime"/> objects.
/// This converter handles <see cref="DateTime"/> values formatted as "yyyy-MM-dd HH:mm:ss".
/// </summary>
public class CustomDateTimeConverter : JsonConverter<DateTime?>
{
    private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String) return null;
        if (DateTime.TryParseExact(reader.GetString(), DateTimeFormat, null, System.Globalization.DateTimeStyles.None, out var dateTime))
        {
            return dateTime;
        }
        return null;
    }

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