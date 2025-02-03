using System.Text.Json;
using TryGetPropertySample.Classes;
using static TryGetPropertySample.Classes.SpectreConsoleHelpers;

namespace TryGetPropertySample;

internal partial class Program
{
    /// <summary>
    /// Processes a JSON string containing student data, calculates the average grade,
    /// and displays the results.
    /// </summary>
    static void Main(string[] args)
    {

        var json =
            /* lang=json*/
            """
            {
              "--environment": "environment",
              "-e": "environment",
              "--username": "username",
              "-u": "username",
              "--log": "log",
              "-l": "log"
            }
            """;
        var values = JsonSerializer.Deserialize<Dictionary<string, string>>(json);

        foreach (var (arg, value) in values)
        {
            Console.WriteLine($"{arg,-15}{value}");
        }

        StudentsSample.ProcessStudentData();
        AppSettingsSamples.CheckMainSectionExistsStrongTyped();
        AppSettingsSamples.CheckMainSectionExistsWeakTyped();
        AppSettingsSamples.CheckMainSectionExistsWeakTypedMisSpelled();
        AppSettingsSamples.CheckIfLogLevelExistsAndGetDefaultLevel();
        AppSettingsSamples.GetLoggingSettings();

        ExitPrompt();
    }
}