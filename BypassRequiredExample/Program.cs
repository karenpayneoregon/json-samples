
using BypassRequiredExample.Classes;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization.Metadata;

namespace BypassRequiredExample;

internal partial class Program
{
    static void Main(string[] args)
    {
        var perfectPeople = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText("Good.json"));

        AnsiConsole.MarkupLine("[cyan]Perfect[/]");
        foreach (var (index, person) in perfectPeople.Index())
        {
            Console.WriteLine($"{index,-4}{person}");
        }

        var imperfectPeople = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText("Bad.json"),
            DismissBirthDateJsonSerializerOptions);

        AnsiConsole.MarkupLine("[cyan]Imperfect[/]");
        foreach (var (index, person) in imperfectPeople.Index())
        {
            Console.WriteLine($"{index,-4}{person}");
        }

        AnsiConsole.MarkupLine("[yellow]To be moved code[/]");

        var jsonString =
            /* language=JSON */
            """
            {
              "BirthDate": "1978-03-04",
              "Id": 1,
              "FirstName": "Mary",
              "LastName": "Jones"
            }
            """;


        JsonNode personNode = JsonNode.Parse(jsonString)!;
        var options = new JsonSerializerOptions { WriteIndented = true };
        Console.WriteLine(personNode!.ToJsonString(options));

        DateOnly birthDate = DateOnly.Parse(personNode!["BirthDate"].ToString());
        Console.WriteLine($"Value={birthDate}");
        Console.ReadLine();
    }
    /// <summary>
    /// Gets the <see cref="JsonSerializerOptions"/> configured to dismiss the required status of the <see cref="Person.BirthDate"/>
    /// property during deserialization.
    /// </summary>
    /// <remarks>
    /// This property is used to provide custom serialization options that ignore the required status of the <see cref="Person.BirthDate"/> property.
    /// </remarks>
    private static JsonSerializerOptions DismissBirthDateJsonSerializerOptions =>
        new()
        {
            TypeInfoResolver = new DefaultJsonTypeInfoResolver
            {
                Modifiers =
                {
                    static typeInfo =>
                    {
                        if (typeInfo.Kind != JsonTypeInfoKind.Object)
                            return;

                        foreach (JsonPropertyInfo propertyInfo in typeInfo.Properties)
                        {
                            if (propertyInfo.Name == nameof(Person.BirthDate))
                            {
                                propertyInfo.IsRequired = false;
                            }
                        }
                    }
                }
            }
        };

}
