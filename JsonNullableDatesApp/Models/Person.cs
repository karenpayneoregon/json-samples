using System.Text.Json.Serialization;
using JsonNullableDatesApp.Classes;

namespace JsonNullableDatesApp.Models;

/// <summary>
/// Represents a person with a name and an optional birthday.
/// </summary>
public class Person
{
    public string Name { get; set; }

    //[JsonConverter(typeof(NullableDateTimeConverter))]
    [JsonConverter(typeof(NullableDateOnlyConverter))]
    public DateOnly? Birthday { get; set; }
}