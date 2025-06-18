

using System.Text.Json;
using ValidateOnStartConsoleApp.Models;

using static ConsoleConfigurationLibrary.Classes.ApplicationValidation;
namespace ValidateOnStartConsoleApp;

internal partial class Program
{
    /// <summary>
    /// The entry point of the console application.
    /// </summary>
    /// <param name="args">
    /// An array of command-line arguments passed to the application.
    /// </param>
    /// <remarks>
    /// This method validates configuration models such as <see cref="ConnectionStrings"/> and <see cref="HelpDesk"/> 
    /// to ensure required properties are populated. It provides feedback on the validation results and handles 
    /// exceptions by displaying error messages in the console. The method also prompts the user to press ENTER 
    /// to exit the application.
    /// </remarks>
    private static void Main(string[] args)
    {

        try
        {
            ValidateOnStart<ConnectionStrings>(nameof(ConnectionStrings), cs => cs.MainConnection);
            Console.WriteLine("Has main connection string");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        try
        {
            ValidateOnStart<ConnectionStrings>(nameof(ConnectionStrings), cs => cs.MainConnection, cs => cs.SecondaryConnection);
            Console.WriteLine("Has both connection strings");
        }
        catch (Exception ex1)
        {
            Console.WriteLine(ex1.Message);
        }

        try
        {
            ValidateOnStart<HelpDesk>(nameof(HelpDesk), hd => hd.Phone, hd => hd.Email);
            Console.WriteLine("Has help desk contact information");
        }
        catch (Exception ex2)
        {
            Console.WriteLine(ex2.Message);
        }
        
        ExitPrompt();
    }
}