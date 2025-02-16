using System.Text.Json;

namespace TryGetPropertySample.Classes;

/// <summary>
/// Represents a sample class for processing student data in JSON format.
/// </summary>
/// <remarks>
/// This class provides functionality to parse and process student data from a JSON string,
/// calculate average grades, and handle missing grade information. It is designed for
/// demonstration and testing purposes.
/// </remarks>
internal class StudentsSample
{
    /// <summary>
    /// Processes a JSON string containing student data, calculates the average grade,
    /// and displays the results. If a student's grade is missing, a default grade of 70 is used.
    /// </summary>
    /// <remarks>
    /// This method parses a JSON document containing student information, iterates through the
    /// student records, and calculates the average grade. It also outputs the grade status
    /// (present or missing) for each student to the console.
    /// </remarks>
    public static void ProcessStudentData()
    {
        PrintCyan();

        var jsonString = MockedStudentsData();

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

        AnsiConsole.MarkupLine($"[white]Average grade :[/] [cyan]{average:F2}[/]");

        Console.WriteLine();

    }
    /// <summary>
    /// Provides a mocked JSON string representing student data for testing purposes.
    /// </summary>
    /// <remarks>
    /// The JSON string contains an array of student objects, each with a "Name" property
    /// and an optional "Grade" property. If the "Grade" property is missing, it is assumed
    /// to be absent intentionally for testing scenarios.
    /// </remarks>
    /// <returns>
    /// A JSON string containing student data, including names and grades.
    /// </returns>
    private static string MockedStudentsData()
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
