using System.Text.Json.Serialization;

namespace JsonLibrary;

/// <summary>
/// Specifies a custom comment to be added to the JSON output during serialization.
/// </summary>
/// <remarks>
/// This attribute is used to annotate properties or fields with a comment that will be included
/// in the serialized JSON output. It leverages a custom JSON converter to append the comment
/// to the serialized data.
/// </remarks>
public sealed class JsonCommentAttribute : JsonConverterAttribute
{
    readonly string Comment;
    public JsonCommentAttribute(string Comment) { this.Comment = Comment; }
    public override JsonConverter CreateConverter(Type typeToConvert) { return new JsonCommentConverter(Comment); }
}