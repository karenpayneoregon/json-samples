namespace DataGridViewCheckBoxApp1.Models;

#pragma warning disable CS8618
public class ProductContainer : Product
{
    private bool _process;

    public ProductContainer(int id)
    {
        ProductId = id;
    }

    public ProductContainer()
    {
        
    }

    public bool Process
    {
        get => _process;
        set
        {
            if (value == _process) return;
            _process = value;
            OnPropertyChanged();
        }
    }
}