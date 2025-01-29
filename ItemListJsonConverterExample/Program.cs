using ItemListJsonConverterExample.Classes;
using System.Text.Json;
using ItemListJsonConverterExample.Converters;
using Spectre.Console.Json;

namespace ItemListJsonConverterExample;

internal partial class Program
{
    static void Main(string[] args)
    {
        var list = new ItemList()
        {
            Group = "Group",
            Items = [new ListItem() { Name = "Foo" }, new ListItem() { Name = "Bar" }
            ]
        };
        
        JsonSerializerOptions.Converters.Add(new ItemListJsonConverter());

        var json = new JsonText(JsonSerializer.Serialize(list, JsonSerializerOptions))
            .MemberColor(Color.Aqua)
            .BracketColor(Color.Green)
            .ColonColor(Color.Blue)
            .CommaColor(Color.Red)
            .StringColor(Color.Green)
            .NumberColor(Color.Blue)
            .BooleanColor(Color.Red)
            .StringColor(Color.White)
            .NullColor(Color.Green);

        AnsiConsole.Write(new Panel(json)
                .Header("Result")
                .Collapse()
                .BorderColor(Color.White));

        Console.ReadLine();
    }

    private static JsonSerializerOptions JsonSerializerOptions =>
        new()
        {
            WriteIndented = true
        };
}