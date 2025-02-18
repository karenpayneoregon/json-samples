using ConsoleConfigurationLibrary.Classes;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using ReadConnectionStringAndCreateNewDatabase.Models;

namespace ReadConnectionStringAndCreateNewDatabase.Classes
{
    /// <summary>
    /// Provides data access operations for interacting with the database, 
    /// including methods for retrieving and processing customer data.
    /// </summary>
    internal class DataOperations
    {
        /// <summary>
        /// Asynchronously retrieves a list of customers from the database, 
        /// including their associated gender information.
        /// </summary>
        /// <remarks>
        /// This method uses Dapper to execute a SQL query that joins the 
        /// Customer and Genders tables, mapping the results to a list of 
        /// <see cref="Customer"/> objects. Each <see cref="Customer"/> object 
        /// includes its associated <see cref="Genders"/> data.
        /// </remarks>
        /// <returns>
        /// A task representing the asynchronous operation. The task result 
        /// contains a list of <see cref="Customer"/> objects with their 
        /// associated gender information.
        /// </returns>
        /// <exception cref="SqlException">
        /// Thrown when there is an issue with the database connection or 
        /// the execution of the SQL query.
        /// </exception>
        public static async Task<List<Customer>> ReadCustomers()
        {

            await using var connection = new SqlConnection(AppConnections.Instance.MainConnection);

            return connection.Query<Customer, Genders, Customer>(
                    SqlStatements.SelectCustomerAndGender,
                    (customer, gender) =>
                    {
                        customer.Gender = gender;
                        return customer;
                    },
                    splitOn: nameof(Genders.Id))
                .ToList();
        }
    }
}
