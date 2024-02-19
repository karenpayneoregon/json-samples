namespace ModelsLibrary.Models;

/// <summary>
/// For [JsonIgnore] on BirthDate in <see cref="PersonIgnoreProperty"/>
/// </summary>
public class Person1
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName => $"{FirstName} {LastName}";

    /// <summary>
    /// Used for demonstration purposes 
    /// </summary>
    public override string ToString() => $"{Id,-4}{FirstName,-12} {LastName}";

}