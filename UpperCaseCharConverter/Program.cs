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
              },
              {
                "Id": 4,
                "FirstName": "carlos",
                "LastName": "garcia",
                "BirthDate": "1992-03-14"
              },
              {
                "Id": 5,
                "FirstName": "laura",
                "LastName": "martinez",
                "BirthDate": "1995-07-20"
              },
              {
                "Id": 6,
                "FirstName": "sofia",
                "LastName": "rodriguez",
                "BirthDate": "1988-05-06"
              },
              {
                "Id": 7,
                "FirstName": "diego",
                "LastName": "gomez",
                "BirthDate": "1979-11-23"
              },
              {
                "Id": 8,
                "FirstName": "marco",
                "LastName": "torres",
                "BirthDate": "1983-08-30"
              },
              {
                "Id": 9,
                "FirstName": "lucia",
                "LastName": "sanchez",
                "BirthDate": "1990-02-14"
              },
              {
                "Id": 10,
                "FirstName": "raul",
                "LastName": "ramirez",
                "BirthDate": "1986-06-18"
              },
              {
                "Id": 11,
                "FirstName": "elena",
                "LastName": "cruz",
                "BirthDate": "1975-10-09"
              },
              {
                "Id": 12,
                "FirstName": "javier",
                "LastName": "ortega",
                "BirthDate": "1969-01-27"
              },
              {
                "Id": 13,
                "FirstName": "natalia",
                "LastName": "ibanez",
                "BirthDate": "1993-12-01"
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