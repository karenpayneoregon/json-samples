using System.Text.Json;

namespace TryGetPropertySample;

internal partial class Program
{
    /// <summary>
    /// Processes a JSON string containing student data, calculates the average grade,
    /// and displays the results.
    /// </summary>
    static void Main(string[] args)
    {
        var jsonString = MockedData();

        double sum = 0;
        int count = 0;

        using (JsonDocument document = JsonDocument.Parse(jsonString))
        {
            JsonElement root = document.RootElement;
            
            JsonElement studentsElement = root.GetProperty("Students");

            foreach (JsonElement student in studentsElement.EnumerateArray())
            {
                var name = student.GetProperty("Name").GetString();

                if (student.TryGetProperty("Grade", out JsonElement gradeElement))
                {
                    AnsiConsole.MarkupLine($"[cyan]{name,-20} has a grade[/]");
                    sum += gradeElement.GetDouble();
                }
                else
                {
                    AnsiConsole.MarkupLine($"[red]{name,-20} has no grade[/]");
                    sum += 70;
                }
                count++;
            }
        }

        double average = sum / count;
        AnsiConsole.MarkupLine($"[white]Average grade :[/] [cyan]{average}[/]");

        Console.ReadLine();
    }

    private static string MockedData()
    {
        var jsonString = 
            /* lang=json*/
            """
            {
              "Students": [
                { "Name": "Alice", "Grade": 85 },
                { "Name": "Bob", "Grade": 90 },
                { "Name": "Charlie" },
                { "Name": "David", "Grade": 78 },
                { "Name": "Eve", "Grade": 92 },
                { "Name": "Frank" }
              ]
            }

            """;
        return jsonString;
    }
}