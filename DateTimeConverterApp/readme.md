# About

Using the `CustomDateTimeConverter` to convert a string to a `DateTime` object.

Taken this [post](https://stackoverflow.com/questions/79220499/system-text-json-jsonexception-in-system-text-json-dll-error-deserializing-da).

## Data

Properties `created_at` and `updated_at` need a converter to properly represent a DateTime.

```json
[
    {
        "id": 1,
        "name": "Raymond Inc",
        "address": "1296 Daniel Road Apt. 349",
        "city": "Pierceview",
        "zip_code": "28301",
        "province": "Colorado",
        "country": "United States",
        "contact_name": "Bryan Clark",
        "contact_phone": "242.732.3483x2573",
        "contact_email": "robertcharles@example.net",
        "created_at": "2010-04-28 02:22:53",
        "updated_at": "2022-02-09 20:22:35"
    },
    {
        "id": 2,
        "name": "Williams Ltd",
        "address": "2989 Flores Turnpike Suite 012",
        "city": "Lake Steve",
        "zip_code": "08092",
        "province": "Arkansas",
        "country": "United States",
        "contact_name": "Megan Hayden",
        "contact_phone": "8892853366",
        "contact_email": "qortega@example.net",
        "created_at": "1973-02-24 07:36:32",
        "updated_at": "2014-06-20 17:46:19"
    }
]
```

## Converter

Found in class project `JsonHelperLibrary`

```csharp
public class CustomDateTimeConverter : JsonConverter<DateTime?>
{
    private const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

    public override DateTime? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.String) return null;
        if (DateTime.TryParseExact(reader.GetString(), DateTimeFormat, null, System.Globalization.DateTimeStyles.None, out var dateTime))
        {
            return dateTime;
        }
        return null;
    }

    public override void Write(Utf8JsonWriter writer, DateTime? value, JsonSerializerOptions options)
    {
        if (value.HasValue)
        {
            writer.WriteStringValue(value.Value.ToString(DateTimeFormat));
        }
        else
        {
            writer.WriteNullValue();
        }
    }
}
```