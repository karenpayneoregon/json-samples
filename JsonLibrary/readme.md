## About

JsonConverter to add comments to json output.
Taken from

https://stackoverflow.com/questions/79285045/how-can-add-comments-when-serialize-to-json


## Example usage

See project `JsonCommentsApp`

```csharp
public class Person
{
    [JsonComment("Name of the person")]
    public string Name { get; set; }

    [JsonComment("Age of the person")]
    public int Age { get; set; }
}
```