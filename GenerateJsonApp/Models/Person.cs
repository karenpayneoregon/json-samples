using System.Text.Json.Serialization;

namespace GenerateJsonApp.Models;
public class Person
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}