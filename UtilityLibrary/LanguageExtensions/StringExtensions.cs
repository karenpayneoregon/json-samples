using System.Text.RegularExpressions;
using static System.Text.RegularExpressions.Regex;

namespace UtilityLibrary.LanguageExtensions;

public static partial class StringExtensions
{
    public static string BetweenBrackets(this string sender)
    {
        var match = ContentWithinBracketsRegex().Match(sender);
        return match.Success ? 
            match.Groups[1].Value : 
            sender;
    }

    public static float[] ToFloatArray(this string sender, char separator = ',') 
        => sender.BetweenBrackets()
            .Split(separator)
            .Select(float.Parse)
            .ToArray();

    [GeneratedRegex(@"\[(.*?)\]")]
    private static partial Regex ContentWithinBracketsRegex();
}