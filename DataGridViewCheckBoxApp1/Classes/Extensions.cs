using System.Data;
using System.Reflection;
using DataGridViewCheckBoxApp1.Models;
using FastMember;

namespace DataGridViewCheckBoxApp1.Classes;
internal static class Extensions
{
    /// <summary>
    /// Convert a list to a DataTable
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="sender">List to convert</param>
    /// <returns>DataTable</returns>
    public static DataTable ToDataTable<T>(this IEnumerable<T> sender)
    {
        DataTable table = new(typeof(T).Name);
        using var reader = ObjectReader.Create(sender);
        table.Load(reader);
        return table;
    }

    /// <summary>
    /// Convert a DataTable to a List of <see cref="Product"/>
    /// </summary>
    /// <param name="table">DataTable to convert</param>
    /// <returns>List of Product</returns>
    public static List<Product>? AllCheckedProducts(this DataTable table) 
        => ConvertDataTable<Product>(table);

    /// <summary>
    /// Convert a DataTable to a List of <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="table">DataTable which can represent <typeparamref name="T"/> </param>
    public static List<T>? ConvertDataTable<T>(this DataTable table) where T : class, new()
    {
        try
        {
            List<T>? list = new List<T>();

            foreach (DataRow row in table.AsEnumerable())
            {
                T item = new T();

                foreach (var pi in item.GetType().GetProperties())
                {
                    try
                    {
                        PropertyInfo? propertyInfo = item.GetType().GetProperty(pi.Name);
                        propertyInfo!.SetValue(item, Convert.ChangeType(row[pi.Name], propertyInfo.PropertyType), null);
                    }
                    catch
                    {
                        // can land here or nullable types
                        continue;
                    }
                }

                list.Add(item);
            }

            return list;
        }
        catch
        {
            return null;
        }
    }


 
}


