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

        StudentsSample.ProcessStudentData();
        AppSettingsSamples.CheckMainSectionExistsStrongTyped();
        AppSettingsSamples.CheckMainSectionExistsWeakTyped();
        AppSettingsSamples.CheckMainSectionExistsWeakTypedMisSpelled();
        AppSettingsSamples.CheckIfLogLevelExistsAndGetDefaultLevel();
        AppSettingsSamples.GetLoggingSettings();

        ExitPrompt();
    }
}