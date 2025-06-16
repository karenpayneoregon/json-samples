using RemovePropertyApp.Classes;
using System.Text.Json;
using System.Text.Json.Nodes;
using Spectre.Console.Json;
using static RemovePropertyApp.Classes.SpectreConsoleHelpers;

namespace RemovePropertyApp;

internal partial class Program
{
    static void Main(string[] args)
    {

        var jsonArray = JsonNode.Parse(File.ReadAllText("peopleIncoming.json"))!.AsArray();

        foreach (var item in jsonArray)
        {
            JsonObject obj = item!.AsObject();
            obj.Remove("Age");
        }

        var updatedJson = jsonArray.ToJsonString(Indented);

        DisplayUpdatedJsonPanel(updatedJson);

        Console.WriteLine();

        File.WriteAllText("People.json", updatedJson);

        var people = JsonSerializer.Deserialize<Person[]>(updatedJson);
        foreach (Person person in people)
        {
            AnsiConsole.MarkupLine($"[pink3]{person.Id,-4}[/]" +
                                   $"[hotpink2]{person.FirstName,-10}{person.LastName}[/]");
        }

        ExitPrompt();

    }

    /// <summary>
    /// Displays the updated JSON content in a styled panel using Spectre.Console.
    /// </summary>
    /// <param name="json">
    /// The JSON string to be displayed in the panel. It is expected to be a well-formatted JSON string.
    /// </param>
    /// <remarks>
    /// This method formats the JSON content with specific colors for various JSON elements, 
    /// such as brackets, colons, strings, numbers, booleans, and null values. 
    /// The content is displayed within a panel with a header, rounded border, and custom border color.
    /// </remarks>
    private static void DisplayUpdatedJsonPanel(string json)
    {
        var jsonText = new JsonText(json)
            .BracketColor(Color.Green)
            .ColonColor(Color.Blue)
            .CommaColor(Color.Yellow)
            .StringColor(Color.Green)
            .NumberColor(Color.White)
            .BooleanColor(Color.Red)
            .MemberColor(Color.DodgerBlue1)
            .NullColor(Color.Green);

        AnsiConsole.Write(
            new Panel(jsonText)
                .Header("People")
                .Collapse()
                .RoundedBorder()
                .BorderColor(Color.Yellow));

    }

    /// <summary>
    /// Gets a <see cref="JsonSerializerOptions"/> instance configured to format JSON with indentation.
    /// </summary>
    /// <value>
    /// A <see cref="JsonSerializerOptions"/> object with <see cref="JsonSerializerOptions.WriteIndented"/> set to <c>true</c>.
    /// </value>
    /// <remarks>
    /// This property is used to ensure that JSON output is formatted with proper indentation for better readability.
    /// </remarks>
    public static JsonSerializerOptions Indented => new() { WriteIndented = true };
}