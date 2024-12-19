using System.Text.Json.Serialization;

namespace JsonLibrary;
public sealed class JsonCommentAttribute : JsonConverterAttribute
{
    readonly string Comment;
    public JsonCommentAttribute(string Comment) { this.Comment = Comment; }
    public override JsonConverter CreateConverter(Type typeToConvert) { return new JsonCommentConverter(Comment); }
}