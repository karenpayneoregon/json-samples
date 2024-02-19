namespace UtilityLibrary;

public class Utilities
{
    public static async Task<string> ReadJsonAsync(string url)
    {
        HttpClient _httpClient = new();
        return await _httpClient.GetStringAsync(url);
    }
}
