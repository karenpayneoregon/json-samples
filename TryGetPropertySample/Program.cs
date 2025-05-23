﻿using System.Text.Json;
using TryGetPropertySample.Classes;

namespace TryGetPropertySample;

internal partial class Program
{
    /// <summary>
    /// Processes a JSON string containing student data, calculates the average grade,
    /// and displays the results.
    /// </summary>
    static void Main(string[] args)
    {
        AppSettingsSamples.GetSectionDemo();

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

        Console.WriteLine();
        AppSettingsSamples.CheckMainSectionExistsStrongTyped();
        Configurations.SectionIsPopulated();

        ExitPrompt();
    }

    private static void ProcessAppSettingsAndStudentData()
    {
        StudentsSample.ProcessStudentData();
        AppSettingsSamples.CheckMainSectionExistsStrongTyped();
        AppSettingsSamples.CheckMainSectionExistsWeakTyped();
        AppSettingsSamples.CheckMainSectionExistsWeakTypedMisSpelled();
        AppSettingsSamples.CheckIfLogLevelExistsAndGetDefaultLevel();
        AppSettingsSamples.GetLoggingSettings();
    }
}