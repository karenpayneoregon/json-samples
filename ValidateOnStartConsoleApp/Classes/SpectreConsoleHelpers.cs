using System.Runtime.CompilerServices;

namespace ValidateOnStartConsoleApp.Classes;
/// <summary>
/// Provides helper methods for interacting with Spectre.Console, 
/// including rendering rules and formatting console output.
/// </summary>
public class SpectreConsoleHelpers
{
    /// <summary>
    /// Displays a prompt in the console instructing the user to press ENTER to exit the application.
    /// </summary>
    /// <remarks>
    /// This method renders a styled message using Spectre.Console to indicate that the user can press ENTER
    /// to terminate the demo. It waits for the user to press ENTER before proceeding.
    /// </remarks>
    public static void ExitPrompt()
    {
        Console.WriteLine();

        Render(new Rule($"[yellow]Press[/] [cyan]ENTER[/] [yellow]to exit the demo[/]")
            .RuleStyle(Style.Parse("silver")).Centered());

        Console.ReadLine();
    }
    /// <summary>
    /// Prints the specified method name in cyan color to the console.
    /// </summary>
    /// <param name="methodName">
    /// The name of the calling method. If not explicitly provided, the caller's method name is automatically used.
    /// </param>
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
}
