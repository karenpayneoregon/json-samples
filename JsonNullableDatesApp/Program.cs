using System.Text.Json;
using JsonNullableDatesApp.Classes;
using JsonNullableDatesApp.Models;

namespace JsonNullableDatesApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        AnsiConsole.MarkupLine("[yellow]People[/]");
        var json = File.ReadAllText("people1.json");

        var people = JsonSerializer.Deserialize<PeopleWrapper>(json, JsonSerializerOptions);
        foreach (var person in people.People)
        {
            Console.WriteLine($"{person.Name, -20}{person.Birthday.Conditional()}");
        }
        Console.ReadLine();
    }

    private static JsonSerializerOptions JsonSerializerOptions => new()
        {
            PropertyNameCaseInsensitive = true,
            WriteIndented = true
        };
}