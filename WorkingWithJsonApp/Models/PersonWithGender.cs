#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace WorkingWithJsonApp.Models;

public class PersonWithGender
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public override string ToString() => $"{Id,-4}{FirstName,-12} {LastName}";
}


