using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.Configuration;

using static ConsoleConfigurationLibrary.Classes.Configuration;

namespace ValidateOnStartConsoleApp.Classes.Configuration;

/// <summary>
/// Provides utility methods for validating and managing connection strings within the application.
/// </summary>
/// <remarks>
/// This class includes methods to check the existence of connection string sections in the configuration
/// and to validate the main and secondary connection strings.
/// </remarks>
public class ConnectionHelpers
{
    /// <summary>
    /// Checks whether the "ConnectionStrings" section exists in the application's configuration.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the "ConnectionStrings" section exists in the configuration; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method retrieves the "ConnectionStrings" section from the application's JSON configuration
    /// and determines its existence using the <see cref="IConfigurationSection.GetSection"/> method.
    /// </remarks>
    public static bool SectionExist() 
        => JsonRoot().GetSection(nameof(ConnectionStrings)).Exists();

    /// <summary>
    /// Checks whether a specified configuration section exists in the application's configuration.
    /// </summary>
    /// <param name="sectionName">
    /// The name of the configuration section to check for existence.
    /// </param>
    /// <returns>
    /// <c>true</c> if the specified configuration section exists; otherwise, <c>false</c>.
    /// </returns>
    /// <remarks>
    /// This method retrieves the specified section from the application's JSON configuration
    /// and determines its existence using the <see cref="IConfigurationSection.GetSection"/> method.
    /// </remarks>
    public static bool SectionExists(string sectionName)
        => JsonRoot().GetSection(sectionName).Exists();

    /// <summary>
    /// Determines whether the main connection string is valid and not empty.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the main connection string is not null, empty, or consists only of white-space characters; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasMainConnection() => !string.IsNullOrWhiteSpace(DataConnections.Instance.MainConnection);
    /// <summary>
    /// Determines whether the secondary connection string is valid and not empty.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the secondary connection string is not null, empty, or consists only of white-space characters; otherwise, <c>false</c>.
    /// </returns>
    public static bool HasSecondaryConnection() => !string.IsNullOrWhiteSpace(DataConnections.Instance.SecondaryConnection);
}
