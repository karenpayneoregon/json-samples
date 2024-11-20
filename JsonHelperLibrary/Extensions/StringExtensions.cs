using System.Globalization;
using System.Text;

namespace JsonHelperLibrary.Extensions;
public static class StringExtensions
{
    /// <summary>
    /// Replaces diacritic characters in the specified text with their non-diacritic equivalents.
    /// </summary>
    /// <param name="text">The input string containing diacritic characters.</param>
    /// <returns>A new string with diacritic characters replaced by their non-diacritic equivalents.</returns>
    public static string ReplaceDiacritics(this string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        var normalizedString = text.Normalize(NormalizationForm.FormD);
        var length = normalizedString.Length;
        StringBuilder stringBuilder = new(length);

        for (var index = 0; index < length; index++)
        {
            char c = normalizedString[index];
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                stringBuilder.Append(c);
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }

    public static string ReplaceDiacritics1(this string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        var normalizedString = text.Normalize(NormalizationForm.FormD);

        string result = new(
            normalizedString
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray()
        );

        return result.Normalize(NormalizationForm.FormC);

    }

    public static string ReplaceDiacritics2(this string text)
    {
        if (string.IsNullOrEmpty(text))
            return text;

        ReadOnlySpan<char> normalizedSpan = text.Normalize(NormalizationForm.FormD).AsSpan();
        var estimatedLength = normalizedSpan.Length;
        char[] result = new char[estimatedLength];
        var resultIndex = 0;

        foreach (char c in normalizedSpan)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                result[resultIndex++] = c;
            }
        }

        return new string(result, 0, resultIndex).Normalize(NormalizationForm.FormC);
    }
    public static string RemoveDiacritics3(this string text)
    {
        ReadOnlySpan<char> normalizedString = text.Normalize(NormalizationForm.FormD);
        int i = 0;
        Span<char> span = text.Length < 1000
            ? stackalloc char[text.Length]
            : new char[text.Length];

        foreach (char c in normalizedString)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                span[i++] = c;
        }

        return new string(span[..i]).Normalize(NormalizationForm.FormC);
    }

}

