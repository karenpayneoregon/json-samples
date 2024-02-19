using System.Data;
using Bogus;
using DataGridViewCheckBoxApp1.Models;
using static Bogus.Randomizer;
namespace DataGridViewCheckBoxApp1.Classes;

public class BogusOperations 
{

    /// <summary>
    /// Create a List of fake <see cref="Products"/>
    /// </summary>
    /// <param name="productCount">How many, if not specified will create a list of 50</param>
    public static List<Product> Products(int productCount = 50)
    {
        int identifier = 1;
        Faker<Product> fake = new Faker<Product>()
            .CustomInstantiator(f => new Product(identifier++))
            .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
            .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(10, 2))
            .RuleFor(p => p.UnitsInStock, f => f.Random.Short(1, 5));

        return fake.Generate(productCount).OrderBy(x => x.ProductName).ToList();
    }

    public static List<ProductContainer> Products1(int productCount = 50)
    {
        Seed = new Random(338);
        int identifier = 1;
        Faker<ProductContainer> fake = new Faker<ProductContainer>()
            .CustomInstantiator(f => new ProductContainer(identifier++))
            .RuleFor(p => p.ProductName, f => f.Commerce.ProductName())
            .RuleFor(p => p.UnitPrice, f => f.Random.Decimal(10, 2))
            .RuleFor(p => p.UnitsInStock, f => f.Random.Short(1, 5));

        return fake.Generate(productCount).OrderBy(x => x.ProductName).ToList();
    }

    /// <summary>
    /// List of <see cref="Products"/> from Bogus to a DataTable
    /// </summary>
    /// <returns></returns>
    public static DataTable ProductsDataTable()
    {
        DataTable table = Products().ToDataTable();

        table.Columns.Add(new DataColumn()
        {
            ColumnName = "Process",
            DataType = typeof(bool),
            // important else default value is null
            DefaultValue = false 
        });

        // Hide primary key in DataGridView
        table.Columns["ProductId"]!.ColumnMapping = MappingType.Hidden;

        // move Process column from last column to first column
        table.Columns["Process"]!.SetOrdinal(0);
        return table;
    }
}