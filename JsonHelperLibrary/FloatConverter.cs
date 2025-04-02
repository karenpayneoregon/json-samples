using System.Globalization;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace JsonHelperLibrary;
/// <summary>
/// Provides a custom JSON converter for handling floating-point numbers.
/// </summary>
public class FloatConverter : JsonConverter<float>
{
    public override float Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) 
        => throw new NotImplementedException();

    /// <summary>
    /// at least one decimal place, add reasonable amount of places with #
    /// </summary>
    /// <param name="writer"></param>
    /// <param name="value"></param>
    /// <param name="options"></param>
    public override void Write(Utf8JsonWriter writer, float value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.ToString("0.0########", CultureInfo.InvariantCulture));
    }
}
