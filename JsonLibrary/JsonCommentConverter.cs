using System.Text.Json;

namespace JsonLibrary;
public class JsonCommentConverter(string comment) : JsonCommentConverter<object>(comment) { }

public class JsonCommentConverter<TBase>(string comment) : DefaultConverterFactory<TBase>
{
    private readonly string _commentWithDelimiters = $" /*{comment}*/";

    protected override void Write<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions modifiedOptions)
    {
        var json = JsonSerializer.Serialize(value, modifiedOptions);
        writer.WriteRawValue(json + _commentWithDelimiters, skipInputValidation: true);
    }

    protected override JsonSerializerOptions ModifyOptions(JsonSerializerOptions options)
    {
        var modifiedOptions = base.ModifyOptions(options);
        modifiedOptions.WriteIndented = false;
        return modifiedOptions;
    }
}