namespace Tinkering;

internal partial class Program
{
    static void Main(string[] args)
    {
        var filePath = "path/to/your/file.txt";
        var dirPath = Path.GetDirectoryName(filePath);

        if (dirPath is not null && Directory.Exists(dirPath) && File.Exists(filePath))
        {
            foreach (var line in File.ReadLines(filePath))
            {
                AnsiConsole.MarkupLine($"[green]{line}[/]");
            }
        }
        else
        {
            Console.WriteLine();
        }

        Console.ReadLine();
    }
}