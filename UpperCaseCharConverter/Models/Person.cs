using JsonHelperLibrary;
using System.Text.Json.Serialization;

namespace UpperCaseCharConverter.Models;

public class Person
{
    public int Id { get; set; }

    [JsonConverter(typeof(UpperCaseFirstCharConverter))]
    public string FirstName { get; set; }
    [JsonConverter(typeof(UpperCaseFirstCharConverter))]
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}
