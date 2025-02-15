using System.Diagnostics;
using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using ConsoleConfigurationLibrary.Models;
using TryGetPropertySample.Models;
using static TryGetPropertySample.Classes.SpectreConsoleHelpers;
using ConnectionStrings = TryGetPropertySample.Models.ConnectionStrings;
using System.Xml.Linq;
using EntityConfiguration = ConsoleConfigurationLibrary.Models.EntityConfiguration;

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

        using var doc = JsonDocument.Parse(MockedConfiguration());
        var result = doc.RootElement.TryGetProperty(nameof(ConnectionStrings), out var connectionStrings) &&
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

        using var doc = JsonDocument.Parse(MockedConfiguration());
        var result = doc.RootElement.TryGetProperty("ConnectionStrings", out var connectionStrings) &&
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

        using var doc = JsonDocument.Parse(MockedConfiguration());
        var result = doc.RootElement.TryGetProperty("ConnectionString", out var connectionStrings) &&
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

        using var doc = JsonDocument.Parse(MockedConfiguration());
        if (doc.RootElement.TryGetProperty("Logging", out var loggingElement) &&
            loggingElement.TryGetProperty("LogLevel", out var logLevelElement) &&
            logLevelElement.TryGetProperty("Default", out var defaultLogLevel))
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
    /// Retrieves and displays the default logging level from the application's configuration.
    /// </summary>
    /// <remarks>
    /// This method accesses the application's configuration file (e.g., appsettings.json),
    /// specifically the "Logging" section, and retrieves the "Default" property within the
    /// "LogLevel" subsection. The retrieved value is displayed in the console.
    /// </remarks>
    /// <example>
    /// Example output:
    /// <code>
    /// Default: Information
    /// </code>
    /// </example>
    /// <seealso cref="Config.Configuration.JsonRoot()"/>
    /// <seealso cref="SpectreConsoleHelpers.PrintCyan(string?)"/>
    /// <seealso cref="AnsiConsole.MarkupLine(string)"/>
    public static void GetLoggingSettings()
    {
        
        PrintCyan();

        // alternate to JsonRoot
        //var configuration = JsonHelpers.ConfigurationBuilder();

        // See project file for an alias on ConsoleConfigurationLibrary package
        var value = Configuration.JsonRoot().GetValue<string>(
            $"{nameof(Logging)}:{nameof(LogLevel)}:{nameof(LogLevel.Default)}");

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


    public static void GetSectionDemo()
    {
        const string fileName = "appsettings1.json";
        const string currentSection = nameof(EntityConfiguration);

        var section = Configuration.JsonRoot(fileName).GetSection(currentSection);
        var exists = section.Exists();

        var tester = Helpers.SectionExists(currentSection);

        var sectionExists = Configuration.JsonRoot(fileName).GetChildren().Any(item => item.Key == currentSection);

        var createNewValue = GetConfigModel<bool>(nameof(EntityConfiguration), nameof(EntityConfiguration.CreateNew));
    }

    public static T GetConfigModel<T>(string section,string name) where T : new()
    {
        if (string.IsNullOrWhiteSpace(name)) return default(T);

        try
        {
            return Configuration.JsonRoot().GetSection(section).GetValue<T>(name);
        }
        catch
        {
            return default(T); // TODO:
        }
    }

}
public class Configurations
{
    public static string GetMainConnectionString()
    {
        var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        return config.GetConnectionString("MainConnection");
    }

}