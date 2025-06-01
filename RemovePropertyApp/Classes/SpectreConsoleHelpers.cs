namespace RemovePropertyApp.Classes;

public static class SpectreConsoleHelpers
{
    /// <summary>
    /// Displays a prompt to the user, instructing them to press ENTER to exit the demo.
    /// </summary>
    /// <remarks>
    /// This method renders a styled message using Spectre.Console and waits for the user to press ENTER.
    /// </remarks>
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

}