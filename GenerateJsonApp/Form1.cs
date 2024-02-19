using GenerateJsonApp.Models;
using System.Text.Json;

namespace GenerateJsonApp;

public partial class Form1 : Form
{
    private static JsonSerializerOptions options = new() { WriteIndented = true };
    public Form1()
    {
        InitializeComponent();
    }

    private void CreatePeopleButton_Click(object sender, EventArgs e)
    {
        File.WriteAllText("people.json",
            JsonSerializer.Serialize(
                new List<Person>
                {
                    new() { Id = 1, FirstName = "Mary", LastName = "Jones" },
                    new() { Id = 2, FirstName = "John", LastName = "Burger" },
                    new() { Id = 3, FirstName = "Anne", LastName = "Adams" }
                }, options));
    }

    private void CreateProductsButton_Click(object sender, EventArgs e)
    {
        File.WriteAllText("products.json",
            JsonSerializer.Serialize(
                new List<Product>
                {
                    new() { Id = "1", Name = "iPhone max"},
                    new() { Id = "2", Name = "iPhone case" },
                    new() { Id = "3", Name = "iPhone ear buds" }
                }, options));
    }

    private void CreatePeopleWithBirthdate_Click(object sender, EventArgs e)
    {
        File.WriteAllText("peopleWithBirthDate.json",
            JsonSerializer.Serialize(
                new List<PersonIgnoreProperty>
                {
                    new() { Id = 1, FirstName = "Mary", LastName = "Jones", BirthDate = new DateOnly(1978,3,4)},
                    new() { Id = 2, FirstName = "John", LastName = "Burger", BirthDate = new DateOnly(1982,5,14) },
                    new() { Id = 3, FirstName = "Anne", LastName = "Adams", BirthDate = new DateOnly(1968,6,9) }
                }, options));
    }
}
