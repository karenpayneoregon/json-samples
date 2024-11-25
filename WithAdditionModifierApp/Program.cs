using System.Text.Json;
using WithAdditionModifierApp.Classes;
using WithAdditionModifierApp.Models;


namespace WithAdditionModifierApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        SerializationCountExample.Run();
        
        Console.WriteLine();

        AnsiConsole.MarkupLine($"[blue]{JsonSerializer.Serialize(new SomeRecord(42), _options)}[/]");

        AnsiConsole.MarkupLine("[yellow]Done[/]");
        Console.ReadLine();
    }


}

