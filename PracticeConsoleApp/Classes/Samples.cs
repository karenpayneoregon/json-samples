using System.Net;
using System.Net.Http.Json;
using PracticeConsoleApp.Models;

namespace PracticeConsoleApp.Classes;
public class Samples
{
    private static readonly HttpClient httpClient = new();

    /// <summary>
    /// This example reads from a static json file in a GitHub repository
    /// </summary>
    public static async Task ReadPersonJson()
    {
        var list = await HttpHelper.ReadList<Person>("https://raw.githubusercontent.com/karenpayneoregon/jsonfiles/main/peopleWithBirthDate.json");


        AnsiConsole.MarkupLine($"[mediumorchid]{ObjectDumper.Dump(list)}[/]");

        Console.WriteLine();
    }

    /// <summary>
    /// Reads a single album from a web service https://jsonplaceholder.typicode.com/albums/1
    /// </summary>
    /// <returns></returns>
    public static async Task ReadAlbumJsonAsync()
    {
        var album = await HttpHelper.ReadSingle<Album>("https://jsonplaceholder.typicode.com/albums/1");
        AnsiConsole.MarkupLine($"[deepskyblue2]{ObjectDumper.Dump(album)}[/]");
        Console.WriteLine();
    }

    /// <summary>
    /// Post an album to a web service https://jsonplaceholder.typicode.com/albums which fakes the actual post.
    /// </summary>
    /// <returns></returns>
    public static async Task PostAlbum()
    {

        Album album = new()
        {
            UserId = 1,
            Id = 100,
            Title = "Greatest hits"
        };

        using var response = await httpClient.PostAsJsonAsync("https://jsonplaceholder.typicode.com/albums", album);

        if (response.StatusCode == HttpStatusCode.Created)
        {
            UriBuilder builder = new(response.Headers.Location.OriginalString);
            
            // get the new id which will always be 101
            var segments = builder.Uri.Segments[^1];

            if (int.TryParse(segments, out var id))
            {
                album.Id = id;
                AnsiConsole.MarkupLine($"[green]Album posted with id {ObjectDumper.Dump(album)}[/]");
            }
        }
        else
        {
            AnsiConsole.MarkupLine($"[red]Failed to post album[/]");
        }

        Console.WriteLine();
    }
}
