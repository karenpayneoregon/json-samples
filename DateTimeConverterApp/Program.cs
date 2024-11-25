using DateTimeConverterApp.Classes;
using System.Text.Json;
using Dumpify;

namespace DateTimeConverterApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        List<Client> list = JsonSerializer.Deserialize<List<Client>>(Json);
        list.Dump();
        Console.ReadLine();
    }

    private static string Json =>
        """
        [
            {
                "id": 1,
                "name": "Raymond Inc",
                "address": "1296 Daniel Road Apt. 349",
                "city": "Pierceview",
                "zip_code": "28301",
                "province": "Colorado",
                "country": "United States",
                "contact_name": "Bryan Clark",
                "contact_phone": "242.732.3483x2573",
                "contact_email": "robertcharles@example.net",
                "created_at": "2010-04-28 02:22:53",
                "updated_at": "2022-02-09 20:22:35"
            },
            {
                "id": 2,
                "name": "Williams Ltd",
                "address": "2989 Flores Turnpike Suite 012",
                "city": "Lake Steve",
                "zip_code": "08092",
                "province": "Arkansas",
                "country": "United States",
                "contact_name": "Megan Hayden",
                "contact_phone": "8892853366",
                "contact_email": "qortega@example.net",
                "created_at": "1973-02-24 07:36:32",
                "updated_at": "2014-06-20 17:46:19"
            }
        ]
        """;
}