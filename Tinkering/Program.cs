using ConsoleConfigurationLibrary.Classes;
using Tinkering.Models;

namespace Tinkering;

internal partial class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Validate ConnectionStrings properties on start
            ApplicationValidation.ValidateOnStart<ConnectionStrings>(
                nameof(ConnectionStrings),
                cs => cs.MainConnection,
                cs => cs.SecondaryConnection
            );
            Console.WriteLine("ConnectionStrings validation succeeded.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Validation failed: {ex.Message}");
        }

        Console.WriteLine("Done");
        Console.ReadLine();
    }
}