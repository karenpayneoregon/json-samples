using ValidateOnStartConsoleApp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using static ConsoleConfigurationLibrary.Classes.Configuration;

namespace ValidateOnStartConsoleApp.Classes.Configuration;

/// <summary>
/// Provides configuration for the application, including service registration and dependency injection setup.
/// </summary>
/// <remarks>
/// This class is responsible for configuring application services and dependencies. It registers services such as 
/// <see cref="SetupServices"/> and binds configuration sections like <see cref="ConnectionStrings"/> to their respective models.
/// The configured services are returned as a <see cref="ServiceCollection"/> for further use in the application.
/// </remarks>
internal class ApplicationConfiguration
{

    /// <summary>
    /// Configures the application's services and dependencies.
    /// </summary>
    /// <remarks>
    /// This method sets up the application's dependency injection container by registering services and binding configuration sections.
    /// It registers the <see cref="SetupServices"/> class and binds the <see cref="ConnectionStrings"/> configuration section to its corresponding model.
    /// The configured services are returned as a <see cref="ServiceCollection"/> for further use in the application.
    /// </remarks>
    /// <returns>
    /// A <see cref="ServiceCollection"/> containing the configured services and dependencies.
    /// </returns>
    public static ServiceCollection ConfigureServices()
    {
        var services = new ServiceCollection();
        ConfigureService(services);

        return services;

        static void ConfigureService(IServiceCollection services)
        {

            services.Configure<ConnectionStrings>(JsonRoot()
                .GetSection(nameof(ConnectionStrings)));

            services.AddTransient<SetupServices>();
        }
    }
}


