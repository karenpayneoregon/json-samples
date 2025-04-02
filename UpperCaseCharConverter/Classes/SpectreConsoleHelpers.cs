using System.Runtime.CompilerServices;
using Spectre.Console.Json;

namespace UpperCaseCharConverter.Classes;
public class SpectreConsoleHelpers
{
    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).Centered());

        Console.ReadLine();
    }
    public static void PrintCyan([CallerMemberName] string? methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]{methodName}[/]");
        Console.WriteLine();
    }
    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    public static void PresentJson(string json)
    {
        AnsiConsole.Write(
            new JsonText(json)
                .BracesColor(Color.Red)
                .BracketColor(Color.Green)
                .ColonColor(Color.White)
                .CommaColor(Color.Cyan1)
                .StringColor(Color.GreenYellow)
                .NumberColor(Color.White)
                .BooleanColor(Color.Red)
                .MemberColor(Color.Yellow)
                .NullColor(Color.Green));
    }
}
