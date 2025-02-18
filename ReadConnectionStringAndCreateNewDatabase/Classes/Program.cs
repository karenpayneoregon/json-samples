using System.Runtime.CompilerServices;
using ConsoleConfigurationLibrary.Models;
using ConsoleConfigurationLibrary.Classes;
using ReadConnectionStringAndCreateNewDatabase.Classes.Exceptions;

// ReSharper disable once CheckNamespace
namespace ReadConnectionStringAndCreateNewDatabase;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {

        ValidateAppsettingsConfiguration();

        AnsiConsole.MarkupLine("");
        Console.Title = "ConsoleConfigurationLibrary Code sample for reading connection strings";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);

    }

    /// <summary>
    /// Validates the configuration in the appsettings.json file to ensure required sections and connection strings are present.
    /// </summary>
    /// <exception cref="AppsettingsMissingConnectionString">
    /// Thrown when the required <c>ConnectionStrings</c> section or the <c>MainConnection</c> connection string
    /// is missing in the appsettings.json file.
    /// </exception>
    private static void ValidateAppsettingsConfiguration()
    {

        if (!Helpers.SectionExists(nameof(ConnectionStrings)))
        {
            throw new AppsettingsMissingSection()
            {
                Section = nameof(ConnectionStrings)
            };
        }

        if (!MainConnectionExists)
        {
            throw new AppsettingsMissingConnectionString()
            {
               Item = nameof(ConnectionStrings.MainConnection)
            };
        }
    }


    /// <summary>
    /// Indicates whether the main database connection string exists in the configuration settings.
    /// </summary>
    /// <remarks>
    /// This property checks if the main connection string is defined and not empty in the application's configuration.
    /// It relies on the <see cref="Helpers.GetSetting{T}"/> method to retrieve the connection string value.
    /// </remarks>
    /// <value>
    /// <c>true</c> if the main connection string exists and is not empty; otherwise, <c>false</c>.
    /// </value>
    public static bool MainConnectionExists =>
        !string.IsNullOrEmpty(Helpers.GetSetting<string>(
            nameof(ConnectionStrings), nameof(ConnectionStrings.MainConnection)));
}

