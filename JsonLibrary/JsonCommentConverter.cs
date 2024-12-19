using System.Text.Json;

namespace JsonLibrary;
public class JsonCommentConverter : JsonCommentConverter<object>
{
    public JsonCommentConverter(string comment) : base(comment) { }
}

public class JsonCommentConverter<TBase> : DefaultConverterFactory<TBase>
{
    readonly string CommentWithDelimiters;

    public JsonCommentConverter(string comment)
    {
        this.CommentWithDelimiters = " /*" + comment + "*/";
    }

    protected override void Write<T>(Utf8JsonWriter writer, T value, JsonSerializerOptions modifiedOptions)
    {
        // TODO: in .NET 9 investigate https://learn.microsoft.com/en-us/dotnet/api/microsoft.toolkit.highperformance.buffers.arraypoolbufferwriter-1 to avoid string allocations.
        var json = JsonSerializer.Serialize(value, modifiedOptions);
        writer.WriteRawValue(json + CommentWithDelimiters, skipInputValidation: true);
    }

    protected override JsonSerializerOptions ModifyOptions(JsonSerializerOptions options)
    {
        var modifiedOptions = base.ModifyOptions(options);
        modifiedOptions.WriteIndented = false;
        return modifiedOptions;
    }
}