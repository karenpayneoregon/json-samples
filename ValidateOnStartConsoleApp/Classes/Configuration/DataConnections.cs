using ValidateOnStartConsoleApp.Models;

namespace ValidateOnStartConsoleApp.Classes.Configuration;
/// <summary>
/// Represents a singleton class that manages known connection strings for the application.
/// </summary>
/// <remarks>
/// This class provides properties to access and validate the main and secondary connection strings.
/// It is implemented as a thread-safe singleton to ensure a single instance is used throughout the application.
///
/// Connection strings are set by the <see cref="SetupServices"/> class during application startup.
/// 
/// </remarks>
public sealed class DataConnections
{
    private static readonly Lazy<DataConnections> Lazy = new(() => new DataConnections());
    /// <summary>
    /// Gets the singleton instance of the <see cref="DataConnections"/> class.
    /// </summary>
    /// <value>
    /// The single, thread-safe instance of the <see cref="DataConnections"/> class, 
    /// which provides access to the application's connection strings.
    /// </value>
    /// <remarks>
    /// This property ensures that only one instance of the <see cref="DataConnections"/> class 
    /// is created and used throughout the application. The instance is initialized lazily 
    /// and is thread-safe.
    /// </remarks>
    public static DataConnections Instance => Lazy.Value;
    /// <summary>
    /// Gets or sets the main connection string for the application.
    /// </summary>
    /// <remarks>
    /// This property holds the primary connection string used by the application to connect to its main data source.
    /// The value is initialized during application startup by the <see cref="SetupServices.GetConnectionStrings"/> method.
    /// </remarks>
    public string MainConnection { get; set; }
    /// <summary>
    /// Gets or sets the secondary connection string for the application.
    /// </summary>
    /// <remarks>
    /// This property holds the secondary connection string used by the application.
    /// It is set during application startup by the <see cref="SetupServices"/> class
    /// and can be validated using the <see cref="ConnectionHelpers.HasSecondaryConnection"/> method.
    /// </remarks>
    public string SecondaryConnection { get; set; }
}