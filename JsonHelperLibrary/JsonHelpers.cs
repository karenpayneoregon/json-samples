using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonHelperLibrary;
/// <summary>
/// Provides a collection of helper methods and predefined <see cref="JsonSerializerOptions"/> 
/// for working with JSON serialization and deserialization in .NET applications.
/// </summary>
/// <remarks>
/// This class includes various preconfigured <see cref="JsonSerializerOptions"/> tailored for 
/// specific use cases, such as case-insensitive property matching, web-based JSON data, 
/// and custom naming policies. It also provides utility methods for JSON deserialization.
/// </remarks>
public class JsonHelpers
{
    /// <summary>
    /// Gets the default <see cref="JsonSerializerOptions"/> used for JSON serialization and deserialization.
    /// </summary>
    /// <remarks>
    /// The options include:
    /// <list type="bullet">
    /// <item>
    /// <description><see cref="JsonSerializerOptions.PropertyNameCaseInsensitive"/> is set to <c>true</c>, enabling case-insensitive matching of property names.</description>
    /// </item>
    /// <item>
    /// <description><see cref="JsonSerializerOptions.WriteIndented"/> is set to <c>true</c>, allowing JSON output to be formatted with indentation for improved readability.</description>
    /// </item>
    /// </list>
    /// </remarks>
    public static readonly JsonSerializerOptions CombinedOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };


    /// <summary>
    /// Provides the default <see cref="JsonSerializerOptions"/> configured for
    /// JSON serialization and deserialization with case-insensitive property names.
    /// </summary>
    public static readonly JsonSerializerOptions CaseInsensitiveOptions = new()
    {
        PropertyNameCaseInsensitive = true
    };

    public static readonly JsonSerializerOptions WebOptions = new(JsonSerializerDefaults.Web)
    {
        WriteIndented = true
    };

    /// <summary>
    /// Retrieves the default <see cref="JsonSerializerOptions"/> configured
    /// to format JSON output with indentation for better readability.
    /// </summary>
    public static readonly JsonSerializerOptions WithWriteIndentOptions = new()
    {
        WriteIndented = true
    };

    /// <summary>
    /// Provides the default <see cref="JsonSerializerOptions"/> configured
    /// to ignore read-only properties during serialization.
    /// </summary>
    public static readonly JsonSerializerOptions WithWriteIndentAndIgnoreReadOnlyPropertiesOptions = new()
    {
        WriteIndented = true, IgnoreReadOnlyProperties = true
    };

    /// <summary>
    /// Provides the default <see cref="JsonSerializerOptions"/> configured
    /// to serialize enums as their string representations and format JSON output with indentation.
    /// </summary>
    public static readonly JsonSerializerOptions EnumJsonSerializerOptions = new()
    {
        Converters = { new JsonStringEnumConverter() }, 
        WriteIndented = true
    };

    /// <summary>
    /// Provides the default <see cref="JsonSerializerOptions"/> configured
    /// to use camel case for property names and format JSON output with indentation.
    /// </summary>
    public static readonly JsonSerializerOptions LowerCaseOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase, 
        WriteIndented = true
    };
    public static readonly JsonSerializerOptions ReadStringAsInteger = new()
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    /// <summary>
    /// Deserializes a JSON string into a list of objects of the specified type.
    /// </summary>
    /// <typeparam name="T">The type of objects to deserialize into.</typeparam>
    /// <param name="json">The JSON string to deserialize.</param>
    /// <returns>
    /// A list of objects of type <typeparamref name="T"/> if the deserialization is successful; 
    /// otherwise, <c>null</c> if the input JSON is invalid or cannot be deserialized.
    /// </returns>
    /// <remarks>
    /// This method uses the <see cref="JsonHelpers.WebOptions"/> for deserialization, 
    /// which includes settings optimized for web-based JSON data.
    /// </remarks>
    public static List<T>? Deserialize<T>(string json)
        => JsonSerializer.Deserialize<List<T>>(json, WebOptions);

    /// <summary>
    /// A custom implementation of <see cref="JsonNamingPolicy"/> that converts property names to lowercase.
    /// </summary>
    /// <remarks>
    /// This naming policy can be used to ensure that all property names in JSON are serialized or deserialized in lowercase.
    /// </remarks>
    public class LowerCaseNamingPolicy : JsonNamingPolicy
    {
        public override string ConvertName(string name) => name.ToLower();
    }

}