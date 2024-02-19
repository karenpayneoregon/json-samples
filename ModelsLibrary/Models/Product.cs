using System.Text.Json.Serialization;

namespace ModelsLibrary.Models;

public class Product
{
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    [JsonPropertyOrder(order: 2)]
    public int Id { get; set; }
    [JsonPropertyOrder(order: 1)]
    public string Name { get; set; }
}