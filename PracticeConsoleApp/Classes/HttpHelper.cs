using System.Net.Http.Json;

namespace PracticeConsoleApp.Classes;

public static class HttpHelper
{
    private static readonly HttpClient HttpClient = new();

    public static async Task<List<T>> ReadList<T>(string uri)
        => await HttpClient.GetFromJsonAsync<List<T>>(uri);

    public static async Task<T> ReadSingle<T>(string uri)
        => await HttpClient.GetFromJsonAsync<T>(uri);
}