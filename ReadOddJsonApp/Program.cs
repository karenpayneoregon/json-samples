using ModelsLibrary.Models;
using ReadOddJsonApp.Classes;
using System.Reflection;
using System.Text.Json;
using JsonHelperLibrary;
using System.Globalization;
using UtilityLibrary.LanguageExtensions;


namespace ReadOddJsonApp;

/// <summary>
/// Off the beaten path code samples for working with json with System.Text.Json
/// </summary>
internal partial class Program
{
    private static JsonSerializerOptions options = new() { Converters = { new FloatConverter() } };
    static async Task Main(string[] args)
    {
        await Task.Delay(0);

        //float[] values = [1f, 1.1f, 4.5555f];
        //var serialize = JsonSerializer.Serialize(values, options);
        //var floatValues = serialize.StringBetweenBrackets().Split(',').Select(float.Parse).ToArray();

        //foreach (var item in floatValues)
        //{
        //    Console.WriteLine(item);
        //}

        //BracketedDataForQuestionOfTheDay();

        //AnsiConsole.MarkupLine("[yellow]Immutable[/]");
        //Json.Immutable();

        //Json.IgnoreNullValues();
        //Json.DumpPeople();
        //Json.IgnoreReadOnlyProperties();

        //Json.WorkingWithEnums();

        //AnsiConsole.MarkupLine("[yellow]Correctly read people with spaces in property names[/]");
        //Json.ReadPeopleWithSpacesInProperties();

        //AnsiConsole.MarkupLine("[yellow]People without birthdate[/]");
        //Json.ReadPeopleIgnoreBirthDate();

        //AnsiConsole.MarkupLine("[red]Intentional failure to read last name property for people[/]");
        //Json.ReadPeopleWithSpacesInPropertiesOoops();

        //AnsiConsole.MarkupLine("[yellow]Case insensitive properties[/]");
        //Json.ReadPeopleCaseInsensitiveProperties();
        //Json.ReadPeopleCaseInsensitiveProperties1();

        //AnsiConsole.MarkupLine("[yellow]Correctly reads with[/] [white on blue].[/] [yellow]in property name[/]");
        //Json.ReadPeopleWithDotsInProperties();

        //await Json.ReadPeopleWithDotsFromWeb();

        //AnsiConsole.MarkupLine("[yellow]Read string property as int[/]");
        //Json.ReadStringPropertyAsInt();

        //Console.WriteLine();
        //AnsiConsole.MarkupLine("[yellow]Casing policy to lowercased property names[/]");
        //Json.CasingPolicy();

        //Console.WriteLine();
        //Console.WriteLine();

        //AnsiConsole.MarkupLine("[yellow]Handling overflows[/]");
        Json.HandleOverflows();


        //DapperOperations operations = new DapperOperations();
        //operations.GetDictionary();

        Console.WriteLine();
        Console.ReadLine();
    }

    private static void BracketedDataForQuestionOfTheDay()
    {
        Console.WriteLine();
        
        const string bracketedData = "[10,20.5,30.88]";
        float[] floatArray = bracketedData.ToFloatArray();

        foreach (var floatItem in floatArray)
        {
            Console.WriteLine(floatItem);
        }

        Console.WriteLine();
    }
}