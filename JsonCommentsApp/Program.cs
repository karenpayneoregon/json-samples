using JsonCommentsApp.Classes;
using System.Text.Json;

namespace JsonCommentsApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        AnsiConsole.MarkupLine("[yellow]Json with comments[/]");
        var person = new Person { Name = "Jack", Age = 22 };

        var json = JsonSerializer.Serialize(person, Options);
        File.WriteAllText("Person.json", json);

        var person2 = JsonSerializer.Deserialize<Person>(json, Options);
        Console.ReadLine();
    }

    public static JsonSerializerOptions Options => new()
    {
        ReadCommentHandling = JsonCommentHandling.Skip, 
        WriteIndented = true
    };
}