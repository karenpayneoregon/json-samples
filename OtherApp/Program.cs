using System.Text.Json;
using OtherApp.Models;

namespace OtherApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        MachineDetails machineDetails = JsonSerializer.Deserialize<MachineDetails>(File.ReadAllText("json.json"));
        
        Example1 class1 = new Example1();
        Example2 class2 = new Example2();


    }
}