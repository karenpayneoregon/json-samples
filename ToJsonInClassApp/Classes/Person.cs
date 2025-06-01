using System.Text.Json;

namespace ToJsonInClassApp.Classes;

/// <summary>
/// Represents a person.
/// </summary>
/// <remarks>
/// Depending on the compilation symbol <c>SERIALIZING</c>, this class may inherit from <see cref="JsonSerializable"/>, 
/// enabling JSON serialization capabilities. When inherited, instances of <see cref="Person"/> can be serialized 
/// into JSON format using the <see cref="JsonSerializer"/>.
/// </remarks>
#if SERIALIZING
public class Person : JsonSerializable
#else
public class Person
#endif
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}