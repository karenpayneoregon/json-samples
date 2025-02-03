using System.Text.Json.Serialization;

namespace TryGetPropertySample.Models;

public class LogLevel
{
    public string Default { get; set; }
    [JsonPropertyName("Microsoft.AspNetCore")]
    public string MicrosoftAspNetCore { get; set; }
}