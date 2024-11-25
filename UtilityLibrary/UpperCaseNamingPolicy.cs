using System.Text.Json;

namespace UtilityLibrary;

/*
 * Microsoft's docs
 * How to customize property names and values with System.Text.Json
 * https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties?pivots=dotnet-8-0
 */

/// <summary>
/// Provides a naming policy for converting property names to uppercase.
/// </summary>
public class UpperCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) =>
        name.ToUpper();
}

/// <summary>
/// Provides a naming policy for converting property names to lowercase.
/// </summary>
public class LowerCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) =>
        name.ToLower();
}

