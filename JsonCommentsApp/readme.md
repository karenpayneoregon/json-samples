# About

Sample for adding comments to json output.

Code is in `JsonLibrary` project.

---

```csharp
public class Person
{
    [JsonComment("Name of the person")]
    public string Name { get; set; }

    [JsonComment("Age of the person")]
    public int Age { get; set; }
}
```

**Resulting json**:

```json
{
  "Name": "Jack" /*Name of the person*/,
  "Age": 22 /*Age of the person*/
}
```