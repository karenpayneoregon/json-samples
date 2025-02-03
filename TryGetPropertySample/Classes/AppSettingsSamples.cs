using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TryGetPropertySample.Models;
using static TryGetPropertySample.Classes.SpectreConsoleHelpers;

namespace TryGetPropertySample.Classes;
internal class AppSettingsSamples
{
    /// <summary>
    /// Checks if the "MainConnection" property exists within the "ConnectionStrings" section
    /// of a JSON configuration file using strongly-typed property names.
    /// </summary>
    /// <remarks>
    /// This method parses a mocked JSON configuration, verifies the presence of the 
    /// "ConnectionStrings" section and its "MainConnection" property, and outputs the result
    /// to the console using colored messages.
    /// </remarks>
    public static void CheckMainSectionExistsStrongTyped()
    {

        PrintCyan();

        using JsonDocument doc = JsonDocument.Parse(MockedConfiguration());
        var result = doc.RootElement.TryGetProperty(nameof(ConnectionStrings), out JsonElement connectionStrings) &&
                     connectionStrings.TryGetProperty(nameof(ConnectionStrings.MainConnection), out _);

        if (result)
        {
            AnsiConsole.MarkupLine("[green]   Main section exists in the configuration file.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]   Main section does not exists in the configuration file.[/]");
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Checks if the "MainConnection" property exists within the "ConnectionStrings" section
    /// of a JSON configuration file using weakly-typed property names.
    /// </summary>
    /// <remarks>
    /// This method parses a mocked JSON configuration, verifies the presence of the 
    /// "ConnectionStrings" section and its "MainConnection" property using string literals, 
    /// and outputs the result to the console with colored messages.
    /// </remarks>
    public static void CheckMainSectionExistsWeakTyped()
    {

        PrintCyan();

        using JsonDocument doc = JsonDocument.Parse(MockedConfiguration());
        var result = doc.RootElement.TryGetProperty("ConnectionStrings", out JsonElement connectionStrings) &&
                     connectionStrings.TryGetProperty("MainConnection", out _);

        if (result)
        {
            AnsiConsole.MarkupLine("[green]   Main section exists in the configuration file.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]   Main section does not exists in the configuration file.[/]");
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Checks if the "MainConnection" property exists within the "ConnectionStrings" section
    /// of a JSON configuration file using weakly-typed property names with a misspelled section name.
    /// </summary>
    /// <remarks>
    /// This method parses a mocked JSON configuration, attempts to verify the presence of the 
    /// "ConnectionStrings" section (note the misspelling) and its "MainConnection" property using string literals, 
    /// and outputs the result to the console with colored messages.
    /// </remarks>
    public static void CheckMainSectionExistsWeakTypedMisSpelled()
    {

        PrintCyan();

        using JsonDocument doc = JsonDocument.Parse(MockedConfiguration());
        var result = doc.RootElement.TryGetProperty("ConnectionString", out JsonElement connectionStrings) &&
                     connectionStrings.TryGetProperty("MainConnection", out _);

        if (result)
        {
            AnsiConsole.MarkupLine("[green]   Main section exists in the configuration file.[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("[red]   Main section does not exists in the configuration file.[/]");
        }

        Console.WriteLine();

    }

    public static void CheckIfLogLevelExistsAndGetDefaultLevel()
    {

        PrintCyan();

        using JsonDocument doc = JsonDocument.Parse(MockedConfiguration());
        if (doc.RootElement.TryGetProperty("Logging", out JsonElement loggingElement) &&
            loggingElement.TryGetProperty("LogLevel", out JsonElement logLevelElement) &&
            logLevelElement.TryGetProperty("Default", out JsonElement defaultLogLevel))
        {
            AnsiConsole.MarkupLine($"   [green]LogLevel Default exists:[/] [white]{defaultLogLevel.GetString()}[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("   [red]LogLevel Default does not exist.[/]");
        }

        Console.WriteLine();

    }

    /// <summary>
    /// Retrieves the default logging level from the "Logging" section of a JSON configuration file.
    /// </summary>
    /// <remarks>
    /// This method parses a mocked JSON configuration, navigates to the "Logging" section, 
    /// and extracts the value of the "Default" property within the "LogLevel" subsection.
    /// </remarks>
    /// <returns>
    /// A string representing the default logging level, such as "Information".
    /// </returns>
    public static void GetLoggingSettings()
    {
        
        PrintCyan();

        var value = JsonDocument.Parse(MockedConfiguration())
                                .RootElement
                                .GetProperty(nameof(Logging))
                                .GetProperty(nameof(LogLevel))
                                .GetProperty(nameof(LogLevel.Default))
                                .GetString();

        AnsiConsole.MarkupLine($"[green]   Default:[/][white] {value}[/]");

        Console.WriteLine();

    }

    /// <summary>
    /// Provides a mocked JSON configuration string for testing purposes skipping reading appsettings.json.
    /// </summary>
    private static string MockedConfiguration()
    {
        var jsonString =
            /* lang=json*/
            """
            {
              "Logging": {
                "LogLevel": {
                  "Default": "Information",
                  "Microsoft.AspNetCore": "Warning"
                }
              },
              "AllowedHosts": "*",
              "ConnectionStrings": {
                "MainConnection": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HasDataExample;Integrated Security=True;Encrypt=False",
                "SecondaryConnection": "..."
              },
              "EntityConfiguration": {
                "CreateNew": true
              }
            }

            """;
        return jsonString;
    }
}