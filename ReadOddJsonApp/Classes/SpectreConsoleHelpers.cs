using Spectre.Console.Json;
using System.Runtime.CompilerServices;

namespace ReadOddJsonApp.Classes;
internal class SpectreConsoleHelpers
{
    /// <summary>
    /// Display json in living color
    /// </summary>
    /// <param name="json">valid json string</param>
    public static void WriteOutJson(string json)
    {
        AnsiConsole.Write(
            new JsonText(json)
                .BracesColor(Color.Red)
                .BracketColor(Color.Green)
                .ColonColor(Color.Blue)
                .CommaColor(Color.Red)
                .StringColor(Color.Green)
                .NumberColor(Color.Blue)
                .BooleanColor(Color.Red)
                .MemberColor(Color.Wheat1)
                .NullColor(Color.Green));
    }

    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).LeftJustified());

        Console.ReadLine();
    }

    private static void Render(Rule rule)
    {
        AnsiConsole.Write(rule);
        AnsiConsole.WriteLine();
    }

    public static void PrintCyan([CallerMemberName] string methodName = null)
    {
        AnsiConsole.MarkupLine($"[cyan]{methodName}[/]");
    }

    public static void LineSeparator()
    {
        AnsiConsole.Write(new Rule().RuleStyle(Style.Parse("grey")).Centered());
    }
}
