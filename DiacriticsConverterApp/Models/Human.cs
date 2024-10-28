using JsonHelperLibrary;
using System.Text.Json.Serialization;

namespace DiacriticsConverterApp.Models;
public class Human
{
    [JsonConverter(typeof(DiacriticsConverter))]
    public string FirstName { get; set; }
    [JsonConverter(typeof(DiacriticsConverter))]
    public string LastName { get; set; }
}
