using System.Text.Json.Serialization;

namespace ModelsLibrary.Models;

public class PersonWithGender
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public Gender Gender { get; set; }
    public override string ToString() => $"{Id,-4}{FirstName,-12} {LastName}";
}


public class PersonWithGender1
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Gender Gender { get; set; }
    public override string ToString() => $"{Id,-4}{FirstName,-12} {LastName}";
}