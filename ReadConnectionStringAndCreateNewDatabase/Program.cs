using ConsoleConfigurationLibrary.Classes;
using ConsoleConfigurationLibrary.Models;
using ReadConnectionStringAndCreateNewDatabase.Classes;
using ReadConnectionStringAndCreateNewDatabase.Classes.Exceptions;

namespace ReadConnectionStringAndCreateNewDatabase;

internal partial class Program
{
    /// <summary>
    /// The SectionExists and the GetSetting methods are used to check if a section exists and value in the configuration file.
    /// These are not normally needed, but are here to show possibilities.
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    private static async Task Main(string[] args)
    {
        await SetupServices.Setup();

        var customers = await DataOperations.ReadCustomers();
        AnsiConsole.MarkupLine(ObjectDumper.Dump(customers)
            .Replace("Customer", "[cyan]Customer[/]")
            .ReplaceGenderVariants("[cyan]Gender[/]"));


        Console.ReadLine();
    }


}