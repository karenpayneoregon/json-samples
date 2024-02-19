using PerfectWorld1.Classes;
using System.Text.Json;
using PerfectWorld1.Models;

namespace PerfectWorld1;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        DataOperations operations = new();
        var json = await operations.ExportToJson();
        await File.WriteAllTextAsync("people.json", json);
        var people = JsonSerializer.Deserialize<List<Person>>(await File.ReadAllTextAsync("people.json"));
        Console.WriteLine(ObjectDumper.Dump(people));
        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }
}