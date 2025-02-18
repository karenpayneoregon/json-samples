namespace ReadConnectionStringAndCreateNewDatabase.Classes.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a required connection string is missing in the appsettings.json file.
/// </summary>
/// <remarks>
/// This exception is specifically used to indicate that a particular connection string, such as <c>MainConnection</c>,
/// is not present in the <c>ConnectionStrings</c> section of the appsettings.json configuration file.
/// </remarks>
public class AppsettingsMissingConnectionString : Exception
{
    /// <summary>
    /// Gets the name of the missing connection string in the <c>appsettings.json</c> file.
    /// </summary>
    /// <value>
    /// The name of the connection string that is missing in the <c>ConnectionStrings</c> section.
    /// </value>
    /// <remarks>
    /// This property is used to specify which connection string, such as <c>MainConnection</c>, 
    /// is not found in the configuration file, aiding in identifying the missing configuration.
    /// </remarks>
    public required string Name { get; init; }
    public override string Message => $"Missing the following connection string {Name} in appsettings.json";
}