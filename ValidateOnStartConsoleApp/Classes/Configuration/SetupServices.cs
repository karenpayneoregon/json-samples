using ValidateOnStartConsoleApp.Models;
using Microsoft.Extensions.Options;

namespace ValidateOnStartConsoleApp.Classes.Configuration;

/// <summary>
/// Provides functionality to configure and manage application services related to connection strings.
/// </summary>
/// <remarks>
/// This class is responsible for initializing and retrieving connection strings from the application's configuration.
/// It utilizes dependency injection to access the configuration options and updates the singleton instance of 
/// <see cref="DataConnections"/> with the retrieved connection strings.
/// </remarks>
internal class SetupServices
{
    private readonly ConnectionStrings _options;

    public SetupServices(IOptions<ConnectionStrings> options)
    {
        _options = options.Value;
    }
    /// <summary>
    /// Retrieves and assigns connection strings from the application's configuration to the singleton instance of 
    /// <see cref="DataConnections"/>.
    /// </summary>
    /// <remarks>
    /// This method reads the connection strings configured in the application and updates the 
    /// <see cref="DataConnections.Instance"/> properties accordingly. It ensures that the connection strings 
    /// are accessible throughout the application.
    /// </remarks>
    public void GetConnectionStrings()
    {
        DataConnections.Instance.MainConnection = _options.MainConnection;
        DataConnections.Instance.SecondaryConnection = _options.SecondaryConnection;
    }
}
