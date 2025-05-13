using OtherApp.Classes;
using System.ComponentModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OtherApp.Models;

// before C# 5
internal class Example1
{
    [DefaultValue(true)]
    public bool Active { get; set; }
    [DefaultValue("Good")]
    public string Mood { get; set; }
    [DefaultValue(1)]
    public int Rating { get; set; }

    public Example1()
    {
        this.ApplyDefaultValues();
    }
}

// Afterwards
internal class Example2
{
    public bool Active { get; set; } = true;
    public string Mood { get; set; } = "Good";
    public int Rating { get; set; } = 1;
}


public interface ISerializeJson
{
    string ToJson();
}

public abstract class JsonSerializable : ISerializeJson
{
    public string ToJson() => JsonSerializer.Serialize(this, GetType(), Options);
    private static JsonSerializerOptions Options => new JsonSerializerOptions { WriteIndented = true };
}
