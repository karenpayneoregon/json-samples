using System.Text.Json;

namespace UtilityLibrary;

/*
 * Microsoft's docs
 * How to customize property names and values with System.Text.Json
 * https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/customize-properties?pivots=dotnet-8-0
 */

public class UpperCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) =>
        name.ToUpper();
}

public class LowerCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name) =>
        name.ToLower();
}

