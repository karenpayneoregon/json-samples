using System.Globalization;

namespace WithAdditionModifierApp.Classes;
public static class StringExtensions
{
    public static string TitleCased(this string sender)
    {
        TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
        return textInfo.ToTitleCase(sender);
    }
}
