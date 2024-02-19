using System.Text.Json.Serialization;

namespace ModelsLibrary.Models;

public class PersonWithDots
{
    public int Id { get; set; }
    [JsonPropertyName("First.Name")]
    public string FirstName { get; set; }
    [JsonPropertyName("Last.Name")]
    public string LastName { get; set; }
    public override string ToString() => $"{Id,-4}{FirstName,-12} {LastName}";
}