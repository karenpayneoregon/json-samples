namespace OtherApp.Models;




public class MachineDetails
{
    public string Status { get; set; }
    public string Count { get; set; }
    public string Code { get; set; }
    public Information[] Information { get; set; }
}
public class Information
{
    public string code { get; set; }
    public DateOnly date { get; set; }
    public Who[] whos { get; set; }
}

public class Who
{
    public string name1 { get; set; }
    public string name2 { get; set; }
}
