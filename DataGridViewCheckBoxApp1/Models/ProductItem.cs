namespace DataGridViewCheckBoxApp1.Models;

#pragma warning disable CS8618

public class ProductItem
{
    public int ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
    public short UnitsInStock { get; set; }

    public static implicit operator ProductItem(Product product) =>
        new()
        {
            ProductId = product.ProductId,
            ProductName = product.ProductName,
            UnitPrice = product.UnitPrice,
            UnitsInStock = product.UnitsInStock,
        };
}

