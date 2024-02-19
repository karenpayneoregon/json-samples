using Dapper;
using kp.Dapper.Handlers;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text.Json;
using PerfectWorld1.Models;

namespace PerfectWorld1.Classes;
internal class DataOperations
{
    private IDbConnection _cn;

    public DataOperations()
    {
        _cn = new SqlConnection(ConnectionString());
        SqlMapper.AddTypeHandler(new SqlDateOnlyTypeHandler());
    }

    private static string ReadPeopleJson =>
        """
        SELECT Id,
               FirstName,
               LastName,
               BirthDate
        FROM dbo.Person

        FOR JSON PATH;

        """;
    public async Task<List<Person>?> DeserializeToList()
        => (JsonSerializer.Deserialize<List<Person>>(
                await _cn.QueryFirstAsync<string>(ReadPeopleJson)))
            .AsList();

    public async Task<string> ExportToJson()
    {
        return await _cn.QueryFirstAsync<string>(ReadPeopleJson);
    }


}
