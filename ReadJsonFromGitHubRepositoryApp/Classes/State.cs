namespace ReadJsonFromGitHubRepositoryApp.Classes;
/// <summary>
/// Represents a united state with a name and an abbreviation.
/// </summary>
public record State(string Name, string Abbreviation)
{
    public override string ToString() => Name;
}

