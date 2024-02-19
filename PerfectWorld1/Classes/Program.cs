using Microsoft.Data.SqlClient;
using System.Runtime.CompilerServices;

// ReSharper disable once CheckNamespace
namespace PerfectWorld1;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        AnsiConsole.MarkupLine("");
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
}

    public static class SqlClientExtensions
    {
        public static DateOnly GetDateOnly(this SqlDataReader reader, int index)
            => reader.GetFieldValue<DateOnly>(index);

        public static TimeOnly GetTimeOnly(this SqlDataReader reader, int index)
            => reader.GetFieldValue<TimeOnly>(index);
    }

