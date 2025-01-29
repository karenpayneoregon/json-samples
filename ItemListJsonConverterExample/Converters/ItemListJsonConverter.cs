using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using ItemListJsonConverterExample.Classes;

namespace ItemListJsonConverterExample.Converters;

/// <summary>
/// Provides a custom JSON converter for the <see cref="ItemList"/> type.
/// </summary>
/// <remarks>
/// This converter handles the serialization of <see cref="ItemList"/> objects
/// into JSON format by iterating over their public properties and writing them
/// as JSON properties.
///
/// Deserialization is not supported and will throw a <see cref="JsonException"/>.
/// 
/// </remarks>
public class ItemListJsonConverter : JsonConverter<ItemList>
{
    public override ItemList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) =>
        throw new JsonException("Not supported for deserialization");

    public override void Write(Utf8JsonWriter writer, ItemList value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        PropertyInfo[] propInfos = typeof(ItemList).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var prop in propInfos)
        {
            var propertyName = prop.Name;
            writer.WritePropertyName(options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);

            JsonSerializer.Serialize(writer, prop.GetValue(value), options);
        }

        writer.WriteEndObject();

    }

}