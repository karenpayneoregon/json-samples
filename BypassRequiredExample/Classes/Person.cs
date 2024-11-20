namespace BypassRequiredExample.Classes;

/// <summary>
/// Represents a person with an ID, first name, last name, and birthdate.
/// </summary>
public class Person
{
    public required DateOnly BirthDate { get; set; }
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public override string ToString() => $"{Id,-4}{FirstName, -12} {LastName,-12}{BirthDate}";

}