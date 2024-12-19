using JsonLibrary;

namespace JsonCommentsApp.Classes;

/// <summary>
/// Represents a person with properties for name and age.
/// </summary>
/// <remarks>
/// Uses the <see cref="JsonCommentAttribute"/> to add comments to the JSON.    
/// </remarks>
public class Person
{
    [JsonComment("Name of the person")]
    public string Name { get; set; }

    [JsonComment("Age of the person")]
    public int Age { get; set; }
}