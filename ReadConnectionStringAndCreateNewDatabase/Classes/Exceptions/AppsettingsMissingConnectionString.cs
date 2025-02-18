namespace ReadConnectionStringAndCreateNewDatabase.Classes.Exceptions;

public class AppsettingsMissingConnectionString : Exception
{
    public required string Item { get; init; }
    public override string Message => $"Missing the following connection string {Item} in appsettings.json";
}