using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using WithAdditionModifierApp.Models;

namespace WithAdditionModifierApp.Classes;

public class SerializationCountExample
{
    /// <summary>
    /// Custom modifier that increments the value of two properties on deserialization.
    /// </summary>
    public static void IncrementCounterModifier(JsonTypeInfo typeInfo)
    {
        foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
        {
            if (propertyInfo.PropertyType != typeof(int))
            {
                continue;
            }

            object[] serializationCountAttributes =
                propertyInfo.AttributeProvider?.GetCustomAttributes(typeof(SerializationCountAttribute), true) ??
                [];

            SerializationCountAttribute attribute = serializationCountAttributes.Length == 1
                ? (SerializationCountAttribute)serializationCountAttributes[0]
                : null;

            if (attribute == null) continue;
            Action<object, object> setProperty = propertyInfo.Set;
            if (setProperty is not null)
            {
                propertyInfo.Set = (obj, value) =>
                {
                    if (propertyInfo.Name == "Count")
                    {
                        value = (int?)value + 10;
                    }
                    else
                    {
                        value = (int?)value + 1;
                    }

                    setProperty(obj, value);
                };
            }
        }
    }

    public static void Run()
    {
        var product = new Product
        {
            Name = "Jim's Stuff",
            RoundTrips = 1,
            Count = 200
        };

        // First serialization and deserialization.
        string serialized = JsonSerializer.Serialize(product, _options);
        AnsiConsole.MarkupLine($"[green]{serialized}[/]");

        Product deserialized = JsonSerializer.Deserialize<Product>(serialized, _options)!;
        AnsiConsole.MarkupLine($"[yellow]RoundTrips:[/] " +
                               $"[cyan]{deserialized.RoundTrips,-3}[/] [yellow]Count:[/] [cyan]{deserialized.Count}[/]");


        // Second serialization and deserialization.
        serialized = JsonSerializer.Serialize(deserialized, _options);
        AnsiConsole.MarkupLine($"[green]{serialized}[/]");

        deserialized = JsonSerializer.Deserialize<Product>(serialized, _options)!;
        AnsiConsole.MarkupLine($"[yellow]RoundTrips:[/] " +
                               $"[cyan]{deserialized.RoundTrips,-3}[/] [yellow]Count:[/] [cyan]{deserialized.Count}[/]");

    }

    private static JsonSerializerOptions _options = new()
    {
        TypeInfoResolver = new DefaultJsonTypeInfoResolver
        {
            Modifiers = { IncrementCounterModifier }
        }
    };
}