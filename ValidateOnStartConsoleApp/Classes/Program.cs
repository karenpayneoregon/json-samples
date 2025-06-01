using System.Runtime.CompilerServices;
using Microsoft.Extensions.DependencyInjection;
using static ConsoleConfigurationLibrary.Classes.ApplicationConfiguration;
using ConsoleConfigurationLibrary.Classes;
using SetupServices = ConsoleConfigurationLibrary.Classes.SetupServices;

// ReSharper disable once CheckNamespace
namespace ValidateOnStartConsoleApp;
internal partial class Program
{
    [ModuleInitializer]
    public static void Init()
    {
        Console.Title = "Code sample";
        WindowUtility.SetConsoleWindowPosition(WindowUtility.AnchorWindow.Center);
    }
    //private static async Task Setup()
    //{
    //    var services = ApplicationConfiguration.ConfigureServices();
    //    await using var serviceProvider = services.BuildServiceProvider();
    //    serviceProvider.GetService<SetupServices>()!.GetConnectionStrings();
    //}

    private static void Setup()
    {
        var services = ConfigureServices();
        using var provider = services.BuildServiceProvider();
        var setup = provider.GetService<SetupServices>();
        setup!.GetConnectionStrings();
        setup.GetEntitySettings();
    }
}
