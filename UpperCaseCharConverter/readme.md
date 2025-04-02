# About

Shows `UpperCaseFirstCharConverter` converter in `JsonHelperLibrary` project to upper case first character of a string.

```csharp
public class Person
{
    public int Id { get; set; }

    [JsonConverter(typeof(UpperCaseFirstCharConverter))]
    public string FirstName { get; set; }
    [JsonConverter(typeof(UpperCaseFirstCharConverter))]
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}
```