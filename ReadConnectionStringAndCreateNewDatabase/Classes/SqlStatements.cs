using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadConnectionStringAndCreateNewDatabase.Classes
{
    internal class SqlStatements
    {
        public static string SelectCustomerAndGender = 
            """"
            SELECT 
                c.Identifier, 
                c.CompanyName, 
                c.ContactName, 
                c.GenderIdentifier,
                g.Id, 
                g.GenderType
            FROM dbo.Customer c
            INNER JOIN dbo.Genders g ON c.GenderIdentifier = g.Id
            """";
    }
}
