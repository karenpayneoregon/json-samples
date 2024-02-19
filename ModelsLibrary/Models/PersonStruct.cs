using System.Text.Json.Serialization;
// ReSharper disable RedundantAssignment

namespace ModelsLibrary.Models;

public readonly struct PersonStruct
{
    public int Id { get;  }

    public string FirstName { get; }

    public string LastName { get; }

    [JsonConstructor]
    public PersonStruct(int id, string firstName, string lastName) =>
        (Id, FirstName, LastName) = (id, firstName, lastName);

    /// <summary>
    /// Used for demonstration purposes 
    /// </summary>
    public override string ToString() => $"{Id, -4}{FirstName,-12}{LastName}";

}