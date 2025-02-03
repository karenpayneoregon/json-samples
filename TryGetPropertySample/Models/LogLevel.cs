using System.Text.Json.Serialization;

namespace TryGetPropertySample.Models;

/// <summary>
/// Represents the log level configuration for various components of the application.
/// </summary>
/// <remarks>
/// This class is used to define the logging levels for different parts of the application.
/// It is typically populated from the application's configuration file (e.g., appsettings.json).
/// </remarks>
public class LogLevel
{
    public string Default { get; set; }
    [JsonPropertyName("Microsoft.AspNetCore")]
    public string MicrosoftAspNetCore { get; set; }
}