using System.Text.RegularExpressions;

namespace ReadConnectionStringAndCreateNewDatabase.Classes;

public static partial class StringExtensions
{
    public static string ReplaceGenderVariants(this string input, string replacement)
    {
        return GenderPattern().Replace(input, replacement);
    }

    [GeneratedRegex(@"\bGender(?!s\b)(?!Type\b)(?!Identifier\b)", RegexOptions.IgnoreCase, "en-US")]
    private static partial Regex GenderPattern();
}