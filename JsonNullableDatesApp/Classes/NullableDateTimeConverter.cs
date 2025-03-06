using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonNullableDatesApp.Classes;

/// <summary>
/// Provides functionality to convert nullable <see cref="DateTime"/> objects to and from JSON.
/// </summary>
/// <remarks>
/// This converter handles special cases such as string representations of "null" and invalid dates like "0000 00 00",
/// ensuring they are deserialized as <c>null</c>. When serializing, valid dates are formatted as "yyyy-MM-dd",
/// and <c>null</c> values are written as JSON null.
/// </remarks>
public class NullableDateTimeConverter : JsonConverter<DateTime?>
{
    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        switch (reader.TokenType)
        {
            case JsonTokenType.String:
            {
                string dateString = reader.GetString();

                // Handle "null" (as a string)
                if (dateString == "null")
                    return null;

                // Handle invalid dates like "0000 00 00"
                if (dateString == "0000 00 00")
                    return null;

                // Try parsing valid dates
                if (DateTime.TryParse(dateString, out DateTime date))
                    return date;
                break;
            }
            case JsonTokenType.Null:
                return null;
        }

        // Default: return null if parsing fails
        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString("yyyy-MM-dd"));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}