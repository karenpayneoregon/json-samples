namespace ReadConnectionStringAndCreateNewDatabase.Classes.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a required section is missing in the appsettings.json file.
/// </summary>
/// <remarks>
/// This exception is specifically used to indicate that a particular section, such as <c>ConnectionStrings</c>,
/// is not present in the appsettings.json configuration file.
/// </remarks>
public class AppsettingsMissingSection : Exception
{
    /// <summary>
    /// Gets the name of the missing section in the appsettings.json file.
    /// </summary>
    /// <remarks>
    /// This property holds the name of the section that is required but not found in the appsettings.json configuration file.
    /// For example, it could be <c>ConnectionStrings</c>.
    /// </remarks>
    public required string Section { get; init; }
    /// <summary>
    /// Gets a message that describes the current exception.
    /// </summary>
    /// <value>
    /// A string containing the error message, which includes the name of the missing section in the appsettings.json file.
    /// </value>
    /// <remarks>
    /// The message provides details about the missing section in the appsettings.json file, 
    /// helping to identify configuration issues.
    /// </remarks>
    public override string Message => $"Missing section {Section} in appsettings.json";
}

