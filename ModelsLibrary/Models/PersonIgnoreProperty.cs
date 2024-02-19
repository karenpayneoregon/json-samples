using System.Text.Json.Serialization;
using ModelsLibrary.LanguageExtensions;

namespace ModelsLibrary.Models;

public class PersonIgnoreProperty : Person1
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public DateOnly BirthDate { get; set; }

    public override string ToString() => $"{Id,-4}{FullName,-20}{nameof(BirthDate)} is default? {(BirthDate == DateOnly.MinValue).ToYesNo()}";

}