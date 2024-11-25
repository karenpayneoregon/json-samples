using System.Text.RegularExpressions;

namespace UtilityLibrary.LanguageExtensions;

public static partial class StringExtensions
{
    /// <summary>
    /// Extracts the content found between the first pair of square brackets in the given string.
    /// </summary>
    /// <param name="sender">The input string from which to extract the content.</param>
    /// <returns>
    /// A string containing the content found between the first pair of square brackets.
    /// If no such content is found, the original string is returned.
    /// </returns>
    public static string BetweenBrackets(this string sender)
    {
        var match = ContentWithinBracketsRegex().Match(sender);
        return match.Success ? 
            match.Groups[1].Value : 
            sender;
    }

    /// <summary>
    /// Converts a delimited string of numbers into an array of floats.
    /// </summary>
    /// <param name="sender">The input string containing the numbers.</param>
    /// <param name="separator">The character used to separate the numbers in the string. Defaults to a comma (',').</param>
    /// <returns>An array of floats parsed from the input string.</returns>
    public static float[] ToFloatArray(this string sender, char separator = ',') 
        => sender.BetweenBrackets()
            .Split(separator)
            .Select(float.Parse)
            .ToArray();

    [GeneratedRegex(@"\[(.*?)\]")]
    private static partial Regex ContentWithinBracketsRegex();
}