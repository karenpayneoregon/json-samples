namespace WorkingWithJsonApp.Models;

/*
 * Without this converter json is represented as a number when serializing and properly deserialize.
 * The benefit for using this attribute is when someone examines the json, it's clear what is member is
 * e.g. rather than 1 we get Female etc.
 *
 * Or see a converter in ReadOddJsonApp.Classes.Json.IgnoreReadOnlyProperties
 * Note going this direction you need to apply options for both serialize and deserializing
 * unlike applying an attribute.
 */
//[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Gender
{
    Unknown,
    Female,
    Male
}
