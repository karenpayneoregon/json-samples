using System.Data;
using System.Text.Json;
using Dapper;
using JsonHelperLibrary;
using Microsoft.Data.SqlClient;

namespace ReadOddJsonApp.Classes;

internal class DapperOperations
{
    private IDbConnection db = new SqlConnection(ConnectionString());

    public void GetDictionary()
    {
        const string statement =
            """
                SELECT EmployeeID as Id, 
                     FirstName + ' ' + LastName AS FullName,
                     LastName
                FROM dbo.Employees ORDER BY LastName;
                """;

        Dictionary<string, int> employeeDictionary = db.Query(statement).ToDictionary(
            row => (string)row.FullName,
            row => (int)row.Id);


        Console.WriteLine(JsonSerializer.Serialize(employeeDictionary, JsonHelpers.WithWriteIndentOptions));
    }
}
