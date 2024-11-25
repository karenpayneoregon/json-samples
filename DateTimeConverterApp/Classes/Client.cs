using System.Text.Json.Serialization;

namespace DateTimeConverterApp.Classes;

public class Client : BaseModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("address")]
    public string Address { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("zip_code")]
    public string ZipCode { get; set; }

    [JsonPropertyName("province")]
    public string Province { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("contact_name")]
    public string ContactName { get; set; }

    [JsonPropertyName("contact_phone")]
    public string ContactPhone { get; set; }

    [JsonPropertyName("contact_email")]
    public string ContactEmail { get; set; }
}