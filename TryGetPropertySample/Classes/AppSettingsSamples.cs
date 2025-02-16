using ConsoleConfigurationLibrary.Classes;
using Microsoft.Extensions.Configuration;
using System.Text.Json;
using TryGetPropertySample.Models;

using static ConsoleConfigurationLibrary.Classes.Configuration;

using ConnectionStrings = TryGetPropertySample.Models.ConnectionStrings;
using EntityConfiguration = ConsoleConfigurationLibrary.Models.EntityConfiguration;

namespace TryGetPropertySample.Classes;
internal class AppSettingsSamples
{
    public static void CheckMainSectionExistsStrongTyped1()
    {
        PrintCyan();

        var configuration = JsonRoot();
        var connectionStringsSection = configuration.GetSection(nameof(ConnectionStrings));
        var result = connectionStringsSection.Exists() &&
                     connectionStringsSection.GetValue<string>(nameof(ConnectionStrings.MainConnection)) != null;

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

    public static void CheckMainSectionExistsStrongTyped()
    {
        PrintCyan();

        var connectionStringsSection = JsonRoot().GetSection(nameof(ConnectionStrings));
        var result = connectionStringsSection.Exists() &&
                     connectionStringsSection.GetValue<string>(nameof(ConnectionStrings.MainConnection)) != null;

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


    public static void CheckMainSectionExistsWeakTyped()
    {
        PrintCyan();

        var connectionStringsSection = JsonRoot().GetSection("ConnectionStrings");
        var result = connectionStringsSection.Exists() &&
                     connectionStringsSection.GetValue<string>("MainConnection") != null;

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

    public static void CheckMainSectionExistsWeakTypedMisSpelled()
    {
        PrintCyan();

        var connectionStringsSection = JsonRoot().GetSection("ConnectionString");
        var result = connectionStringsSection.Exists() &&
                     connectionStringsSection.GetValue<string>("MainConnection") != null;

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

        var logLevelSection = JsonRoot().GetSection("Logging:LogLevel");
        var defaultLogLevel = logLevelSection.GetValue<string>("Default");

        if (defaultLogLevel != null)
        {
            AnsiConsole.MarkupLine($"   [green]LogLevel Default exists:[/] [white]{defaultLogLevel}[/]");
        }
        else
        {
            AnsiConsole.MarkupLine("   [red]LogLevel Default does not exist.[/]");
        }

        Console.WriteLine();
    }

    public static void GetLoggingSettings()
    {
        PrintCyan();

        var value = JsonRoot().GetValue<string>(
            $"{nameof(Logging)}:{nameof(LogLevel)}:{nameof(LogLevel.Default)}");

        AnsiConsole.MarkupLine($"[green]   Default:[/][white] {value}[/]");

        Console.WriteLine();
    }

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

        var section = JsonRoot(fileName).GetSection(currentSection);
        var exists = section.Exists();

        var tester = Helpers.SectionExists(currentSection);

        var sectionExists = JsonRoot(fileName).GetChildren().Any(item => item.Key == currentSection);

        var createNewValue = GetSetting<bool>(nameof(EntityConfiguration), nameof(EntityConfiguration.CreateNew));
    }

    /// <summary>
    /// Retrieves a strongly-typed value from the application configuration based on the specified section and name.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the value to retrieve. Must have a parameterless constructor.
    /// </typeparam>
    /// <param name="section">
    /// The name of the configuration section containing the desired setting.
    /// </param>
    /// <param name="name">
    /// The name of the setting within the specified section.
    /// </param>
    /// <returns>
    /// The value of the specified setting as type <typeparamref name="T"/> if found; otherwise, the default value of <typeparamref name="T"/>.
    /// </returns>
    /// <remarks>
    /// If the specified section or name is invalid, or if an error occurs during retrieval, the method returns the default value of <typeparamref name="T"/>.
    /// </remarks>
    public static T GetSetting<T>(string section, string name) where T : new()
    {
        if (string.IsNullOrWhiteSpace(name)) return default(T);

        try
        {
            return JsonRoot().GetSection(section).GetValue<T>(name);
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

    public static void SectionIsPopulated()
    {
        if (Helpers.SectionExists(nameof(ConnectionStrings)))
        {
            var connectionStringsSection = JsonRoot().GetSection(nameof(ConnectionStrings));
            ConnectionStrings test = connectionStringsSection.Get<ConnectionStrings>();

            var hasBothConnectionStrings =
                !string.IsNullOrWhiteSpace(test.MainConnection) &&
                !string.IsNullOrWhiteSpace(test.SecondaryConnection);

            Console.WriteLine($"     MainConnection {!string.IsNullOrWhiteSpace(test.MainConnection)}");
            Console.WriteLine($"SecondaryConnection {!string.IsNullOrWhiteSpace(test.SecondaryConnection)}");
            Console.WriteLine(hasBothConnectionStrings);
        }
        else
        {
            Console.WriteLine("Missing");

        }
    }
}
