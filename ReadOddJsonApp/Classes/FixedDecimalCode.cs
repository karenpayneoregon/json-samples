using JsonHelperLibrary;
using ModelsLibrary.Models;
using System.Text.Json;

namespace ReadOddJsonApp.Classes;

internal class FixedDecimalCode
{
    private static JsonSerializerOptions _options = new()
    {
        WriteIndented = true,
        Converters = { new FixedDecimalJsonConverter() }
    };

    public static void CreateProductsDataForFixedDecimalConverter()
    {
        List<Products> list =
        [
            new() { Id = 1, Name = "Phone", UnitPrice = 1200.99m },
            new() { Id = 2, Name = "Case", UnitPrice = 20.45m }
        ];

        var json = JsonSerializer.Serialize(list);
    }

    public static void ReadProducts()
    {

        var products = JsonHelpers.Deserialize<Products>(
            """
                    [
                      {
                        "Id": 1,
                        "Name": "Phone",
                        "UnitPrice": "1200.99"
                      },
                      {
                        "Id": 2,
                        "Name": "Case",
                        "UnitPrice": "20.45"
                      }
                    ]
                    """);

        products.ForEach(Console.WriteLine);
    }
}

