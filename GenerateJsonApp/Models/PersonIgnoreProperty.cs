using System.Text.Json.Serialization;

namespace GenerateJsonApp.Models;

public class PersonIgnoreProperty : Person
{
    //[JsonIgnore]
    public DateOnly BirthDate { get; set; }
}