using Spectre.Console.Json;
using ToJsonInClassApp.Classes;

namespace ToJsonInClassApp;

internal partial class Program
{
    private static void Main(string[] args)
    {

        Person person = new()
        {
            Id = 1,
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateOnly(1980, 1, 1)
        };

        var json = new JsonText(person.ToJson())
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
        AnsiConsole.MarkupLine("\n\n[yellow]Done[/]");
        Console.ReadLine();
    }
}