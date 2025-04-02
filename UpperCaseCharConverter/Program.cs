using System.Text.Json;
using UpperCaseCharConverter.Models;
using static UpperCaseCharConverter.Classes.SpectreConsoleHelpers;

namespace UpperCaseCharConverter;

internal partial class Program
{
    static void Main(string[] args)
    {


        string mockedJson =
            /*lang=json*/
            """
            [
              {
                "Id": 1,
                "FirstName": "jose",
                "LastName": "fernandez",
                "BirthDate": "1985-01-01"
              },
              {
                "Id": 2,
                "FirstName": "miguel",
                "LastName": "lopez",
                "BirthDate": "1970-12-04"
              },
              {
                "Id": 3,
                "FirstName": "angel",
                "LastName": "perez",
                "BirthDate": "1980-09-11"
              }
            ]
            """;
        var people = JsonSerializer.Deserialize<List<Person>>(mockedJson, Options);
        var json = JsonSerializer.Serialize(people, Options);
        PresentJson(json);
        ExitPrompt();
    }

    private static JsonSerializerOptions Options =>
        new()
        {
            WriteIndented = true
        };
}