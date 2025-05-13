# About

Came across this [question](https://stackoverflow.com/questions/79618017/why-does-an-inherited-class-not-get-json-serialized-correctly) .

The class `JsonSerializable` implements the `ISerializeJson` interface and provides a method `ToJson()` that serializes the object to JSON format using `System.Text.Json`.

Note that `WriteIndented` is optional

```csharp
public interface ISerializeJson
{
    string ToJson();
}

public abstract class JsonSerializable : ISerializeJson
{
    public string ToJson() => JsonSerializer.Serialize(this, GetType(), Options);
    private static JsonSerializerOptions Options => new JsonSerializerOptions { WriteIndented = true };
}

public class Person : JsonSerializable
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateOnly BirthDate { get; set; }
}
```
