namespace TryGetPropertySample.Models;

/// <summary>
/// Represents the logging configuration for the application.
/// </summary>
/// <remarks>
/// This class is used to define and manage the logging settings, including log levels
/// for various components of the application. It is typically populated from the 
/// application's configuration file (e.g., appsettings.json).
/// </remarks>
public class Logging
{
    public LogLevel LogLevel { get; set; }
}