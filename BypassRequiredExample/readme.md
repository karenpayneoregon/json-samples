# Required properties

You can mark certain properties to signify that they must be present in the JSON payload for deserialization to succeed. Similarly, you can set an option to specify that all non-optional constructor parameters are present in the JSON payload. If one or more of these required properties is not present, the JsonSerializer.Deserialize methods throw a JsonException.

:books: Microsoft [docs](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/required-properties)