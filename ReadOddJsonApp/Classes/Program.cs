using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace ReadOddJsonApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Json code samples";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}
