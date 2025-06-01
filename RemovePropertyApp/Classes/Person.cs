using System.Text.Json.Serialization;

namespace RemovePropertyApp.Classes;

/// <summary>
/// Represents a person with an identifier, first name, and last name.
/// </summary>
/// <remarks>
/// The <c>Age</c> property is not included in this class. 
/// The <c>FirstName</c> property is mapped to the JSON property <c>Name</c>, 
/// and the <c>LastName</c> property is mapped to the JSON property <c>Last</c>.
/// </remarks>
public class Person
{
    public int Id { get; set; }
    [JsonPropertyName("Name")]
    public string FirstName { get; set; }
    [JsonPropertyName("Last")]
    public string LastName { get; set; }
}