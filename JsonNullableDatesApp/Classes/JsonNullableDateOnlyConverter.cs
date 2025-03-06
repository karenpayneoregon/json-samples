using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonNullableDatesApp.Classes;

/// <summary>
/// Provides a custom JSON converter for nullable <see cref="DateOnly"/> values.
/// </summary>
/// <remarks>
/// This converter handles serialization and deserialization of nullable <see cref="DateOnly"/> values
/// using a specific date format. It ensures proper handling of null values and invalid date representations.
///
/// Taken from https://www.conradakunga.com/blog/writing-a-custom-dateonly-json-deserializer/
/// </remarks>
public class JsonNullableDateOnlyConverter : JsonConverter<DateOnly?>
{
    // Define the date format the data is in
    private const string DateFormat = "yyyy MM dd";


    // This is the deserializer
    public override DateOnly? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var input = reader.GetString();
        if (!string.IsNullOrEmpty(input) && input != "null" && input != "0000 00 00")
            return DateOnly.ParseExact(reader.GetString()!,
                DateFormat);
        else
        {
            return null;
        }
    }


    // This is the serializer
    public override void Write(Utf8JsonWriter writer, DateOnly? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
            writer.WriteStringValue(value.Value.ToString(
                DateFormat, CultureInfo.InvariantCulture));
    }
}