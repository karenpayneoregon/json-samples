using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace RemovePropertyApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Updated Code Sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
