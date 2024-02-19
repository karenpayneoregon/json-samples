namespace ModelsLibrary.Models;

public class Products
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal UnitPrice { get; set; }
    public override string ToString() => $"{Id,-4}{Name,-12}{UnitPrice,12}";
}