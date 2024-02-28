using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

// ReSharper disable once CheckNamespace
namespace WithAdditionModifierApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }

    private static JsonSerializerOptions _options = new()
    {
        TypeInfoResolver = Models.SomeContext.Default
            .WithAddedModifier(static typeInfo =>
            {
                foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
                {
                    if (propertyInfo.PropertyType != typeof(int))
                    {
                        continue;
                    }

                    propertyInfo.Name = propertyInfo.Name.ToUpperInvariant();


                }
            })
    };
}