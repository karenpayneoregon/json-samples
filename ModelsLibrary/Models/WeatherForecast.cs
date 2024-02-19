using System.Text.Json.Serialization;
using System.Text.Json;

namespace ModelsLibrary.Models;

public class WeatherForecast
{
    public DateTimeOffset Date { get; set; }
    public int TemperatureCelsius { get; set; }
    public string Summary { get; set; }
    [JsonExtensionData]
    public Dictionary<string, JsonElement> ExtensionData { get; set; }
}