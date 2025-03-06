using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonNullableDatesApp.Classes;

public class NullableDateOnlyConverter : JsonConverter<DateOnly?>
{
    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.Null)
        {
            return null;
        }

        string dateString = reader.GetString();
        if (DateOnly.TryParse(dateString, out DateOnly date))
        {
            return date;
        }
        else
        {
            return null;
        }
    }
    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
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