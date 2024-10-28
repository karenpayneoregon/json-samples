using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        string normalizedString = text.Normalize(NormalizationForm.FormD);

        StringBuilder stringBuilder = new();

        foreach (char c in normalizedString)
        {
            if (!CharUnicodeInfo.GetUnicodeCategory(c).Equals(UnicodeCategory.NonSpacingMark))
                stringBuilder.Append(c);
        }

        return stringBuilder.ToString();
    }
}

