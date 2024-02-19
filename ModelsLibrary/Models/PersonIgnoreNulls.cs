using System.Text.Json.Serialization;

namespace ModelsLibrary.Models;

/// <summary>
/// Demo on how to control writing json out with null values for properties
///
/// Microsoft docs
/// https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/ignore-properties?pivots=dotnet-7-0
/// </summary>
public class PersonIgnoreNulls
{
    public int Id { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string FirstName { get; set; }
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public string LastName { get; set; }

    /// <summary>
    /// Used for demonstration purposes 
    /// </summary>
    public override string ToString() => $"{Id,-4}{FirstName,-12} {LastName}";

}