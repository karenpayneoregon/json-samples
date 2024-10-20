
using JsonConvertersSampleApp.Classes;
using System.ComponentModel;
using System.Text.Json;
using JsonConvertersSampleApp.Models;

namespace JsonConvertersSampleApp;

public partial class MainForm : Form
{
    BindingList<Taxpayer> _taxpayersBindingList;
    BindingSource BindingSource = new();
    public MainForm()
    {
        InitializeComponent();

        _taxpayersBindingList = new BindingList<Taxpayer>(BogusOperations.TaxpayerList());
        BindingSource.DataSource = _taxpayersBindingList;
        listBox1.DataSource = BindingSource;
        var json = JsonSerializer.Serialize(_taxpayersBindingList, Options);
        textBox1.Text = json;

        List<Taxpayer> person = JsonSerializer.Deserialize<List<Taxpayer>>(json);


    }

    private static JsonSerializerOptions Options =>
        new()
        {
            WriteIndented = true
        };

    private void DeserializeButton_Click(object sender, EventArgs e)
    {
        using ChildForm f = new(_taxpayersBindingList.ToList());
        f.ShowDialog();
    }
}
