#nullable enable
using System.Text.Json;
using System.Text.Json.Serialization;
using JsonHelperLibrary;
using ModelsLibrary.Models;
using UtilityLibrary;
using static ReadOddJsonApp.Classes.SpectreConsoleHelpers;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CA1869

namespace ReadOddJsonApp.Classes;

/*
 * JsonSerializerOptions should be at class level for real applications while
 * not done here for clarity of each usage in methods below which in some cases
 * are configured differently from each other.
 */
internal class Json
{
    public static List<PersonIgnoreNulls> CreatePeopleWithNulls() =>
    [
        new() { Id = 1, FirstName = null, LastName = "Jones" },
        new() { Id = 2, FirstName = "John", LastName = "Smith" },
        new() { Id = 3, FirstName = null, LastName = "Adams" }
    ];

    public static List<PersonWithGender> CreatePeopleWithGender() =>
    [
        new() { Id = 1, FirstName = "Anne", LastName = "Jones", Gender = Gender.Female},
        new() { Id = 2, FirstName = "John", LastName = "Smith", Gender = Gender.Male},
        new() { Id = 3, FirstName = "Bob", LastName = "Adams", Gender = Gender.Unknown}
    ];


    public static void DumpPeople()
    {
        
        File.WriteAllText("Json\\peopleDump.json",
            JsonSerializer.Serialize(
                CreatePeopleWithNulls(), JsonHelpers.WithWriteIndentOptions));
    }

    /// <summary>
    /// In this case we do not want to write <see cref="Person.FullName"/> which is a read-only
    /// property to the json file.
    ///
    /// Microsoft's docs
    /// https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.ignorereadonlyproperties?view=net-7.0
    /// </summary>
    public static void IgnoreReadOnlyProperties()
    {
        
        List<Person> CreatePeopleWithReadOnlyProperty() =>
        [
            new() { Id = 1, FirstName = "Jill", LastName = "Jones" },
            new() { Id = 2, FirstName = "John", LastName = "Smith" },
            new() { Id = 3, FirstName = "Bill", LastName = "Adams" }
        ];

        File.WriteAllText("Json\\peopleDumpWithoutFullName.json",
            JsonSerializer.Serialize(
                CreatePeopleWithReadOnlyProperty(), JsonHelpers.WithWriteIndentAndIgnoreReadOnlyPropertiesOptions));
    }

    public static void WorkingWithEnums()
    {

        List<PersonWithGender> people = CreatePeopleWithGender();
        var json = JsonSerializer.Serialize(people, JsonHelpers.EnumJsonSerializerOptions);
        
        WriteOutJson(json);
        List<PersonWithGender>? list = JsonSerializer.Deserialize<List<PersonWithGender>>(
            json, 
            JsonHelpers.EnumJsonSerializerOptions);

        Console.WriteLine();
        Console.WriteLine();
        list.ForEach(Console.WriteLine);
    }

    /// <summary>
    /// Demonstration for custom casing
    /// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties?pivots=dotnet-8-0
    /// </summary>
    public static void CasingPolicy()
    {
        var json = SerializeLowerCasing();

        DeserializeLowerCasing(json);
        
    }

    public static string SerializeLowerCasing()
    {
        return JsonSerializer.Serialize(
            new List<Product>
            {
                new() { Id = 1, Name = "iPhone max"},
                new() { Id = 2, Name = "iPhone case" },
                new() { Id = 3, Name = "iPhone ear buds" }
            }, JsonHelpers.LowerCaseOptions);
    }

    public static void DeserializeLowerCasing(string json)
    {
        List<Product>? products = JsonSerializer.Deserialize<List<Product>>(json, JsonHelpers.LowerCaseOptions);
        WriteOutJson(json);

        Console.WriteLine();
        Console.WriteLine();
        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id,-3}{product.Name}");
        }
    }

    /// <summary>
    /// Reads all data properly
    /// </summary>
    public static void ReadPeopleWithSpacesInProperties()
    {
        var people = JsonSerializer.Deserialize<List<Person>>(
            """
            [
              {
                "Id": 1,
                "First Name": "Mary",
                "Last Name": "Jones"
              },
              {
                "Id": 2,
                "First Name": "John",
                "Last Name": "Burger"
              },
              {
                "Id": 3,
                "First Name": "Anne",
                "Last Name": "Adams"
              }
            ]
            """);
        foreach (var person in people!)
        {
            Console.WriteLine(person);
        }
    }

    /// <summary>
    /// Does not read last name as in this case there are no spaces in the LastName property, but we
    /// told JsonSerializer there are spaces in the LastName property
    /// </summary>
    public static void ReadPeopleWithSpacesInPropertiesOoops()
    {
        var people = JsonSerializer.Deserialize<List<Person>>(File.ReadAllText("Json\\people2.json"));
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }

    public static async Task ReadPeopleWithDotsFromWeb()
    {
        var json = await Utilities.ReadJsonAsync("https://raw.githubusercontent.com/karenpayneoregon/jsonfiles/main/people4.json");
        var people = JsonSerializer.Deserialize<List<PersonWithDots>>(json);
        people.ForEach(Console.WriteLine);
    }

    public static void ReadPeopleWithDotsInProperties()
    {
        var people = JsonSerializer.Deserialize<List<PersonWithDots>>(
            """
            [
              {
                "Id": 1,
                "First.Name": "Mary",
                "Last.Name": "Jones"
              },
              {
                "Id": 2,
                "First.Name": "John",
                "Last.Name": "Burger"
              },
              {
                "Id": 3,
                "First.Name": "Anne",
                "Last.Name": "Adams"
              }
            ]
            """);
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }

    public static void ReadPeopleIgnoreBirthDate()
    {
        var people = JsonSerializer.Deserialize<List<PersonIgnoreProperty>>(File.ReadAllText("Json\\peopleWithBirthDate.json"));
        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }
    /// <summary>
    /// Deserialize case insensitive
    /// </summary>
    public static void ReadPeopleCaseInsensitiveProperties()
    {
        List<PersonCasing>? people = JsonSerializer.Deserialize<List<PersonCasing>>(
            """
            [
              {
                "Id": 1,
                "firstname": "Mary",
                "lastname": "Jones"
              },
              {
                "id": 2,
                "firstnaMe": "John",
                "lastNAme": "Burger"
              },
              {
                "iD": 3,
                "firstname": "Anne",
                "lastname": "Adams"
              }
            ]
            """,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        foreach (var person in people)
        {
            Console.WriteLine(person);
        }
    }

    /// <summary>
    /// Microsoft's docs
    /// How to handle overflow JSON
    /// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/handle-overflow?pivots=dotnet-7-0
    /// </summary>
    /// <remarks>
    /// Pretty much a steal from Microsoft docs with minor adjustments
    /// </remarks>
    public static void HandleOverflows()
    {

        var json =
            """
            {
              "Date": "2019-08-01T00:00:00-07:00",
              "temperatureCelsius": 25,
              "Summary": "Hot",
              "DatesAvailable": [
                "2019-08-01T00:00:00-07:00",
                "2019-08-02T00:00:00-07:00"
              ],
              "SummaryWords": [
                "Cool",
                "Windy",
                "Humid"
              ]
            }
            """;

        WeatherForecast? weatherForecast = JsonSerializer.Deserialize<WeatherForecast>(json);

        JsonSerializerOptions serializeOptions = new() { WriteIndented = true };
        json = JsonSerializer.Serialize(weatherForecast, serializeOptions);

        WriteOutJson(json);
    }

    /// <summary>
    /// Microsoft's docs
    /// Use immutable types and properties
    /// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/immutability
    /// </summary>
    public static void Immutable()
    {
        var json =
            """
            [
               {
                 "Id": 1,
                 "FirstName": "Mary",
                 "LastName": "Jones"
               },
               {
                 "Id": 2,
                 "FirstName": "John",
                 "LastName": "Burger"
               },
               {
                 "Id": 3,
                 "FirstName": "Anne",
                 "LastName": "Adams"
               }
            ]
            """;

        var options = new JsonSerializerOptions(JsonSerializerDefaults.Web);
        List<PersonStruct>? peopleReadOnly = JsonSerializer.Deserialize<List<PersonStruct>>(json, options);
        peopleReadOnly.ForEach(peep => Console.WriteLine(peep));
    }


    /// <summary>
    /// Here in products.json, Id property is a string and the model <see cref="Product.Id"/> is an int.
    /// To read the Id property as an int use NumberHandling as per below.
    ///
    /// Microsoft's docs
    /// https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsonserializeroptions.numberhandling?view=net-7.0
    /// </summary>
    public static void ReadStringPropertyAsInt()
    {
        var jsonOptions = new JsonSerializerOptions()
        {
            NumberHandling = JsonNumberHandling.AllowReadingFromString
        };

        List<Product>? products = JsonSerializer.Deserialize<List<Product>>(
            """
            [
              {
                "Id": "1",
                "Name": "iPhone max"
              },
              {
                "Id": "2",
                "Name": "iPhone case"
              },
              {
                "Id": "3",
                "Name": "iPhone ear buds"
              }
            ]
            """, 
            jsonOptions);

        foreach (var product in products)
        {
            Console.WriteLine($"{product.Id,-4:D2}{product.Name}");
        }

    }

    public static void IgnoreNullValues()
    {
        PersonWithGender person1 = new() { FirstName = "Karen", LastName = "Payne", Gender = Gender.Female};
        var data1 = JsonSerializer.Serialize(person1, JsonHelpers.EnumJsonSerializerOptions);
        PersonWithGender1 person2 = new() { FirstName = "Karen", LastName = "Payne" };
        var data2 = JsonSerializer.Serialize(person2, JsonHelpers.WithWriteIndentOptions);
    }
}
