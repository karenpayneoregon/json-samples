using DataGridViewCheckBoxApp1.Classes;
using DataGridViewCheckBoxApp1.Models;
using System.ComponentModel;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

namespace DataGridViewCheckBoxApp1;
public partial class Form2 : Form
{
    private BindingSource _bindingSource = new();
    private SortableBindingList<ProductContainer> _bindingList;


    private static readonly JsonSerializerOptions JsonSerializerOptions = new()
    {
        WriteIndented = true,
        Converters = { new FixedDecimalJsonConverter() }
    };


    private static readonly JsonSerializerOptions _jsonDeserializerOptions = new JsonSerializerOptions
    {
        NumberHandling = JsonNumberHandling.AllowReadingFromString
    };

    public Form2()
    {
        InitializeComponent();
    }

    private void Form2_Load(object sender, EventArgs e)
    {
        _bindingList = new SortableBindingList<ProductContainer>(BogusOperations.Products1());
        _bindingSource.DataSource = _bindingList;
        dataGridView1.DataSource = _bindingSource;

        dataGridView1.Columns["ProductId"]!.Visible = false;

        dataGridView1.FixHeaders();
        dataGridView1.ExpandColumns();

        dataGridView1.Columns["UnitPrice"]!.DefaultCellStyle.Format = "C2";
        dataGridView1.Columns["UnitsInStock"]!.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
    }

    private void ToggleCurrentButton_Click(object sender, EventArgs e)
    {
        ProductContainer? current = _bindingList[_bindingSource.Position];
        if (current == null) return;
        current.Process = !current.Process;
    }

    /// <summary>
    /// Get all selected, lose the process column and write to a json file
    /// in the application folder
    /// </summary>
    private void GetAllCheckedButton_Click(object sender, EventArgs e)
    {
        List<ProductContainer> products = _bindingList.Where(pc => pc.Process).ToList();

        List<ProductItem> results = products
            .Select<Product, ProductItem>(container => container).ToList();

        if (results.Any())
        {
            // process checked
            File.WriteAllText("Products.json", JsonSerializer.Serialize(results, JsonSerializerOptions));

            var json = File.ReadAllText("Products.json");
            List<Product>? productsFromFile = JsonSerializer.Deserialize<List<Product>>(json, _jsonDeserializerOptions);
            // set breakpoint below to see the results
        }
        else
        {
            // nothing checked
        }
    }

    /// <summary>
    /// Check/uncheck all
    /// </summary>
    private void CheckAllButton_Click(object sender, EventArgs e)
    {
        foreach (var container in _bindingList)
        {
            container.Process = DirectionCheckBox.Checked;
        }
    }
}
