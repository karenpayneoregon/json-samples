namespace ReadConnectionStringAndCreateNewDatabase.Models;

public class Customer
{
    public int Identifier { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public int? GenderIdentifier { get; set; }
    public Genders Gender { get; set; } // Navigation Property
}