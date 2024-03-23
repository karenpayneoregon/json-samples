using System.Text.Json.Serialization;

namespace PracticeConsoleApp.Models;

public class Album
{
    [JsonPropertyName("userId")]
    public int UserId { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string Title { get; set; }

    public override string ToString() => $"{Id,-4}{Title}";

}