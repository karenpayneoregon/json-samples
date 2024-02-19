using System.Text.Json;
using System.Text.Json.Serialization;
using JsonHelperLibrary;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary.Models;

namespace WorkingWithJsonApp.Classes;

public class JsonSamples
{
    public List<PersonWithGender> CreatePeopleWithGender() =>
    [
        new() { Id = 1, FirstName = "Anne", LastName = "Jones", Gender = Gender.Female },
        new() { Id = 2, FirstName = "John", LastName = "Smith", Gender = Gender.Male },
        new() { Id = 3, FirstName = "Bob", LastName = "Adams", Gender = Gender.Unknown }
    ];

    public void WorkingWithEnums(JsonOptions options)
    {

        List<PersonWithGender> people = CreatePeopleWithGender();
        var json = JsonSerializer.Serialize(people, 
            options.JsonSerializerOptions);
        List<PersonWithGender>? list = JsonSerializer.Deserialize<List<PersonWithGender>>(json, 
            options.JsonSerializerOptions);
    }

}
