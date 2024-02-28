using System.Text.Json.Serialization;

namespace WithAdditionModifierApp.Models;

[JsonSerializable(typeof(SomeRecord))]
public partial class SomeContext : JsonSerializerContext { }