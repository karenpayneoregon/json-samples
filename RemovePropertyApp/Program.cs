using RemovePropertyApp.Classes;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace RemovePropertyApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var json = PeopleJson();

        var jsonArray = JsonNode.Parse(json)!.AsArray();

        foreach (var item in jsonArray)
        {
            var obj = item!.AsObject();
            obj.Remove("Age");
        }

        var updatedJson = jsonArray.ToJsonString(Indented);
        
        AnsiConsole.Write(
            new Panel(Markup.Escape(updatedJson))
                .Header(" People without age")
                .Collapse()
                .RoundedBorder()
                .Padding(2,2,2,2)
                .BorderColor(Color.Pink1));
        
        Console.WriteLine();

        var people = JsonSerializer.Deserialize<Person[]>(updatedJson);
        foreach (Person person in people)
        {
            AnsiConsole.MarkupLine($"[pink3]{person.Id,-4}[/]" +
                                   $"[hotpink2]{person.FirstName,-10}{person.LastName}[/]");
        }

        AnsiConsole.MarkupLine("[yellow]Continue[/]");
        Console.ReadLine();
    }

    private static string PeopleJson() =>
            /* lang=json*/
            """
            [
              {
                "Id": 1,
                "Name": "Mary",
                "Last": "Jones",
                "Age": 22
              },
              {
                "Id": 2,
                "Name": "John",
                "Last": "Burger",
                "Age": 44
              },
              {
                "Id": 3,
                "Name": "Anne",
                "Last": "Adams",
                "Age": 33
              }
            ]
            """;



    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
}