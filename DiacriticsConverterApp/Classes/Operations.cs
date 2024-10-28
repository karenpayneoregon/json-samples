using DiacriticsConverterApp.Models;
using JsonHelperLibrary;
using Spectre.Console.Json;
using System.Text.Json;

namespace DiacriticsConverterApp.Classes;
internal class Operations
{
    /// <summary>
    /// Demonstrates the serialization using <see cref="DiacriticsConverter"/> of a list of people with diacritic characters in their names to JSON,
    /// applies custom JSON formatting, and writes the JSON to a file.
    /// </summary>
    public static void Sample()
    {
        List<Human> people =
        [
            new() { FirstName = "María", LastName = "García" },
            new() { FirstName = "José", LastName = "Rodríguez" },
            new() { FirstName = "Luis", LastName = "González" },
            new() { FirstName = "Carlos", LastName = "Fernández" },
            new() { FirstName = "Andrés", LastName = "López" },
            new() { FirstName = "Manuel", LastName = "Sánchez" },
            new() { FirstName = "Francisco", LastName = "Pérez" },
            new() { FirstName = "Juan", LastName = "Gómez" },
            new() { FirstName = "Fernando", LastName = "Díaz" },
            new() { FirstName = "Sergio", LastName = "Hernández" },
            new() { FirstName = "Álvaro", LastName = "Alvarado" },
            new() { FirstName = "Diego", LastName = "Ramírez" }
        ];

        string jsonString = JsonSerializer.Serialize(people, _options);
        
        var json = new JsonText(jsonString)
            .MemberColor(Color.Aqua)
            .BracketColor(Color.Green)
            .ColonColor(Color.Blue)
            .CommaColor(Color.Red)
            .StringColor(Color.Green)
            .NumberColor(Color.Blue)
            .BooleanColor(Color.Red)
            .StringColor(Color.White)
            .NullColor(Color.Green);

        AnsiConsole.Write(json);
        Console.WriteLine();

        File.WriteAllText("humans.json", jsonString);
    }

    private static readonly JsonSerializerOptions _options = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };
}
