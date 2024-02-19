using System.Data;

namespace DataGridViewCheckBoxApp1.Classes;
public static class BindingSourceExtensions
{
    public static DataRow CurrentRow(this BindingSource sender)
    {
        return ((DataRowView)sender.Current).Row;
    }

    public static DataTable DataTable(this BindingSource sender)
        => (DataTable)sender.DataSource;
}
