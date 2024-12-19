using System.Text.Json;

namespace JsonLibrary;

public static class JsonExtensions
{
    /// <summary>
    /// Creates a copy of the specified <see cref="JsonSerializerOptions"/> and removes any converters of the specified type.
    /// </summary>
    /// <param name="options">
    /// The <see cref="JsonSerializerOptions"/> instance to copy.
    /// </param>
    /// <param name="converterType">
    /// The <see cref="Type"/> of the converter to remove from the copied options.
    /// </param>
    /// <returns>
    /// A new <see cref="JsonSerializerOptions"/> instance with the specified converter type removed.
    /// </returns>
    public static JsonSerializerOptions CopyAndRemoveConverter(this JsonSerializerOptions options, Type converterType)
    {
        var copy = new JsonSerializerOptions(options);
        for (var index = copy.Converters.Count - 1; index >= 0; index--)
        {
            if (copy.Converters[index].GetType() == converterType)
            {
                copy.Converters.RemoveAt(index);
            }
        }

        return copy;
    }
}