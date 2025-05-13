using System.Text.Json;

namespace ToJsonInClassApp.Classes;

/// <summary>
/// Represents a person with properties Id, first name, last name, and birthdate.
/// </summary>
/// <remarks>
/// This class inherits from <see cref="JsonSerializable"/>, enabling instances of <see cref="Person"/> 
/// to be serialized into JSON format using the <see cref="JsonSerializer"/>.
/// </remarks>
public class Person : JsonSerializable
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}