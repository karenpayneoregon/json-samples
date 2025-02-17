using ConsoleConfigurationLibrary.Models;
using Microsoft.Extensions.Configuration;
using static ConsoleConfigurationLibrary.Classes.Configuration;
using System.Linq.Expressions;
namespace ValidateOnStartConsoleApp.Classes.Configuration;

/// <summary>
/// Provides functionality to validate application configuration during startup.
/// </summary>
/// <remarks>
/// This class ensures that essential configuration sections, such as connection strings, 
/// are present and properly configured when the application starts. It leverages helper 
/// methods to check the existence of configuration sections and retrieve required settings.
/// </remarks>
public class ApplicationValidation
{
    /// <summary>
    /// Validates the application's configuration during startup.
    /// </summary>
    /// <remarks>
    /// This method ensures that essential configuration sections, such as connection strings, 
    /// are present and properly configured. It retrieves the "ConnectionStrings" section and 
    /// validates the main connection string to ensure the application can operate correctly.
    /// </remarks>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the required "ConnectionStrings" section or the main connection string is missing or invalid.
    /// </exception>
    public static void ValidateOnStart()
    {
        if (ConnectionHelpers.SectionExist())
        {
            var section = JsonRoot().GetRequiredSection(nameof(ConnectionStrings));
            var value = section?.GetValue<string>(nameof(ConnectionStrings.MainConnection));
            if (value != null)
            {
                Connection.Validator(value);
            }
            else
            {
                throw new ApplicationException($"Missing property '{nameof(ConnectionStrings.MainConnection)}'");
            }
        }
        else
        {
            throw new InvalidOperationException($"The required configuration section '{nameof(ConnectionStrings)}' is missing.");
        }
    }

    /// <summary>
    /// Validates a specific configuration section and a property within it during application startup.
    /// </summary>
    /// <typeparam name="T">
    /// The type of the configuration section to validate. Must be a reference type.
    /// </typeparam>
    /// <param name="sectionName">
    /// The name of the configuration section to validate.
    /// </param>
    /// <param name="propertySelector">
    /// A function that selects a specific property from the configuration section for validation.
    /// </param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if the required configuration section is missing or if the selected property is null.
    /// </exception>
    /// <remarks>
    /// This method ensures that the specified configuration section exists and retrieves its value.
    /// It uses the provided <paramref name="propertySelector"/> to validate a specific property within the section.
    /// If the configuration section or the selected property is not properly configured, an exception is thrown.
    /// </remarks>
    public static void ValidateOnStart<T>(string sectionName, Expression<Func<T, string>> propertySelector) where T : class
    {
        if (ConnectionHelpers.SectionExist())
        {
            var section = JsonRoot().GetRequiredSection(sectionName).Get<T>();

            if (section is not null)
            {
                var compiledSelector = propertySelector.Compile();
                var propertyName = GetPropertyName(propertySelector);
                var value = compiledSelector(section);
                if (value is not null)
                {
                    Connection.Validator(value);
                }
                else
                {
                    throw new InvalidOperationException($"The required property '{propertyName}' is missing");
                }
            }
        }
        else
        {
            throw new InvalidOperationException($"The required configuration section '{sectionName}' is missing.");
        }
    }

    /// <summary>
    /// Retrieves the name of the property specified in the given expression.
    /// </summary>
    /// <typeparam name="T">The type of the object containing the property.</typeparam>
    /// <param name="propertySelector">
    /// An expression that specifies the property for which the name is to be retrieved.
    /// </param>
    /// <returns>The name of the property specified in the expression.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if the provided <paramref name="propertySelector"/> expression is invalid or does not represent a property.
    /// </exception>
    private static string GetPropertyName<T>(Expression<Func<T, string>> propertySelector)
    {
        if (propertySelector.Body is MemberExpression memberExpression)
        {
            return memberExpression.Member.Name;
        }
        else if (propertySelector.Body is UnaryExpression { Operand: MemberExpression operandExpression })
        {
            return operandExpression.Member.Name;
        }

        throw new ArgumentException("Invalid property selector expression", nameof(propertySelector));
    }
}

/// <summary>
/// 
/// </summary>
public class Connection
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="connectionString"></param>
    /// <returns></returns>
    public static bool Validator(string connectionString)
    {
        return true;
    }
}