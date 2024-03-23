using System.Net;
using System.Net.Http.Json;

namespace PracticeConsoleApp.Classes;
public static class HttpHelper
{
    private static readonly HttpClient httpClient = new();

    public static async Task<List<T>> ReadList<T>(string uri)
        => await httpClient.GetFromJsonAsync<List<T>>(uri);

    public static async Task<T> ReadSingle<T>(string uri)
        => await httpClient.GetFromJsonAsync<T>(uri);


}