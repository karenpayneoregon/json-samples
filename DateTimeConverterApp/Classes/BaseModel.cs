using System.Text.Json.Serialization;
using JsonHelperLibrary;

namespace DateTimeConverterApp.Classes;

public class BaseModel
{
    [JsonPropertyName("created_at")]
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime? CreatedAt { get; set; }

    [JsonPropertyName("updated_at")]
    [JsonConverter(typeof(CustomDateTimeConverter))]
    public DateTime? UpdatedAt { get; set; }
}