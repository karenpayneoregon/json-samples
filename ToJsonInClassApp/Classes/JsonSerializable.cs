using System.Text.Json;
using ToJsonInClassApp.Interfaces;

namespace ToJsonInClassApp.Classes;
/// <summary>
/// Represents an abstract base class that provides functionality for serializing to JSON format.
/// </summary>
/// <remarks>
/// This class implements the <see cref="ISerializeJson"/> interface, 
/// enabling derived classes to serialize themselves into JSON using the <see cref="System.Text.Json.JsonSerializer"/>.
/// </remarks>
public abstract class JsonSerializable : ISerializeJson
{
    public string ToJson() => JsonSerializer.Serialize(this, GetType(), Options);
    private static JsonSerializerOptions Options => new JsonSerializerOptions { WriteIndented = true };
}