using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonLibrary;

public abstract class DefaultConverterFactory<TBase> : JsonConverterFactory
{
    // Adapted from this answer https://stackoverflow.com/a/78512783/3744182
    // To https://stackoverflow.com/questions/78507408/in-system-text-json-is-it-possible-to-minify-only-array-items
    class DefaultConverter<TConcrete> : JsonConverter<TConcrete> where TConcrete : TBase
    {
        readonly JsonSerializerOptions modifiedOptions;
        readonly DefaultConverterFactory<TBase> factory;

        public DefaultConverter(JsonSerializerOptions modifiedOptions, DefaultConverterFactory<TBase> factory) { this.modifiedOptions = modifiedOptions; this.factory = factory; }

        public override void Write(Utf8JsonWriter writer, TConcrete value, JsonSerializerOptions options) { factory.Write(writer, value, modifiedOptions); }
        // In .NET 9 use
        // return public override TConcrete? Read
        public override TConcrete Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) { return factory.Read<TConcrete>(ref reader, typeToConvert, modifiedOptions); }
    }

    protected virtual JsonSerializerOptions ModifyOptions(JsonSerializerOptions options) { return options.CopyAndRemoveConverter(this.GetType()); }

    // In .NET 9 use
    // return public override T? Read(
    protected virtual TConcrete Read<TConcrete>(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions modifiedOptions) where TConcrete : TBase
    {
        // In .NET 9 use
        // return (T?)
        return ((TConcrete)JsonSerializer.Deserialize(ref reader, typeToConvert, modifiedOptions)!)!;
    }

    protected virtual void Write<TConcrete>(Utf8JsonWriter writer, TConcrete value, JsonSerializerOptions modifiedOptions) where TConcrete : TBase
    {
        JsonSerializer.Serialize(writer, value, modifiedOptions);
    }

    public sealed override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var modifiedOptions = ModifyOptions(options);
        if (typeToConvert == typeof(TBase))
        {
            return new DefaultConverter<TBase>(modifiedOptions, this);
        }
        else
            // In .NET 9 apply ! to the end of this line to suppress a nullable warning
        {
            return ((JsonConverter)Activator.CreateInstance(typeof(DefaultConverter<>)
                .MakeGenericType(typeof(TBase), typeToConvert), [modifiedOptions, this])!)!;
        }
    }

    public override bool CanConvert(Type typeToConvert) { return typeof(TBase).IsAssignableFrom(typeToConvert); }
}