using WithAdditionModifierApp.Classes;

namespace WithAdditionModifierApp.Models;

public class Product
{
    public string Name { get; set; } = "";
    [SerializationCount]
    public int RoundTrips { get; set; }
    [SerializationCount]
    public int Count { get; set; }
}