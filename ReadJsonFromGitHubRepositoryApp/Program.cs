using ReadJsonFromGitHubRepositoryApp.Classes;
using System.Text.Json;

namespace ReadJsonFromGitHubRepositoryApp;

internal partial class Program
{
    static async Task Main(string[] args)
    {
        /*
         * Original source of the JSON
         * https://github.com/karenpayneoregon/json-samples/blob/master/unitedStates.json
         *
         * Below is set up to read the JSON from a GitHub repository in a raw format
         */
        const string url = "https://raw.githubusercontent.com/karenpayneoregon/json-samples/master/unitedStates.json";
        var states = await Operations.LoadFromUrlAsync(url);
        foreach (var state in states)
        {
            AnsiConsole.MarkupLine($"[yellow]{state.Abbreviation,-5}[/][cyan]{state.Name}[/]");
        }
        AnsiConsole.MarkupLine("[yellow]Continue[/]");
        Console.ReadLine();
    }

}

// Belows in a separate file named Operations.cs under Classes folder
public class Operations
{
    public static async Task<List<State>> LoadFromUrlAsync(string url)
    {
        using var client = new HttpClient();

        var json = await client.GetStringAsync(url);

        var states = JsonSerializer.Deserialize<List<State>>(json, CachedJsonSerializerOptions);

        return states ?? [];
    }

    private static readonly JsonSerializerOptions CachedJsonSerializerOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };
}