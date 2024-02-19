using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models;
using UtilityLibrary;
using WorkingWithJsonApp.Classes;
using JsonHelperLibrary;
using Microsoft.Extensions.Options;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace WorkingWithJsonApp.Pages;
public class IndexModel : PageModel
{
    private readonly IOptions<JsonOptions> _options;

    public IndexModel(IOptions<JsonOptions> options)
    {
        _options = options;
    }

    [BindProperty]
    public string PersonWithDotsList { get; set; }

    [BindProperty]
    public List<Product> StringAsIntList { get; set; }

    [BindProperty]
    public string ProductsStringAsInt { get; set; }


    public async Task OnGet()
    {
        await PropertiesWithDots();

        StringAsIntList = await ReadProductsWithIntAsStringFromWeb();

        Log.Information("Products");
        foreach (var product in StringAsIntList)
        {
            Log.Information("{P1,-3:D2} {P2}", product.Id, product.Name);
        }

        JsonSamples samples = new();
        samples.WorkingWithEnums(_options.Value);
        JsonResult result = CasingIssues();
    }

    // Shows how to read a model with properties with dots
    private async Task PropertiesWithDots()
    {
        PersonWithDotsList = await Utilities.ReadJsonAsync("https://raw.githubusercontent.com/karenpayneoregon/jsonfiles/main/people4.json");
        var people = JsonSerializer.Deserialize<List<PersonWithDots>>(PersonWithDotsList);

        foreach (var person in people!)
        {
            Log.Information("{P1,-3:D2} {P2,-10} {P3}", person.Id, person.FirstName, person.LastName);
        }
    }

    // An example for reading string to int
    public async Task<List<Product>> ReadProductsWithIntAsStringFromWeb()
    {

        var json = await Utilities.ReadJsonAsync(
            "https://raw.githubusercontent.com/karenpayneoregon/jsonfiles/main/products.json");
        ProductsStringAsInt = json;

        return JsonSerializer.Deserialize<List<Product>>(json, JsonHelpers.WebOptions)!;

    }

    // Demonstrates reading properties in json that casing does not match the model/class
    public JsonResult CasingIssues()
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
            """, _options.Value.JsonSerializerOptions);

        Log.Information("Case");

        foreach (var person in people)
        {
            Log.Information("{P1,-3:D2} {P2,-10} {P3}", person.Id, person.FirstName, person.LastName);
        }


        return new JsonResult(people);

    }

    public static List<PersonWithGender> CreatePeopleWithGender() =>
    [
        new() { Id = 1, FirstName = "Anne", LastName = "Jones", Gender = Gender.Female },
        new() { Id = 2, FirstName = "John", LastName = "Smith", Gender = Gender.Male },
        new() { Id = 3, FirstName = "Bob", LastName = "Adams", Gender = Gender.Unknown }
    ];


}
