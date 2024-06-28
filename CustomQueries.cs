using Microsoft.Data.SqlClient;
using Microsoft.Identity.Client;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeavyTruckApp
{
    internal class CustomQueries
    {
        public static DataTable StatusQuery(string connectionString, string tableName)
        {
            DataTable dataTable = new DataTable();

            string query = @"
                 DECLARE @TableName NVARCHAR(255) = '" + tableName + @"';
                DECLARE @SQLQuery NVARCHAR(MAX);
                SET @SQLQuery = '
                    SELECT
                        STX.JobSequence,
                        STX.SetNumber,
                        STX.PartNumber,
                        STX.JobNumber,
                        STX.ProductCode,
                        STX.ProductName,
                        STX.[Date],
                        STX.ISAControl,
                        MSTX.Status
                    FROM
                        ' + @TableName + ' STX
                    LEFT JOIN
                        MasterSTXJoblist MSTX ON MSTX.JobNumber = STX.JobNumber;';
                EXEC sp_executesql @SQLQuery;
                ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error executing query: " + ex.Message);
                }
            }
            return dataTable;

        }

        public static bool CreateAndLoadTableFromCSV(string connectionString, string csvFilePath, string tableName)
        {
            bool success = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    //Create the table with a structure that matches CSV File
                    string createTableQuery = @"
                    CREATE TABLE " + tableName + @" (
                        JobSequence NVARCHAR(255),
                        SetNumber NVARCHAR(255),
                        PartNumber NVARCHAR(255),
                        JobNumber NVARCHAR(255),
                        ProductCode NVARCHAR(255),
                        ProductName NVARCHAR(255),
                        [Date] NVARCHAR(255),
                        ISAControl NVARCHAR(255),
                        )";
                    SqlCommand createTableCommand = new SqlCommand(createTableQuery, connection);
                    createTableCommand.ExecuteNonQuery();

                    // Load data from CSV into the table
                    string loadDataQuery = @"
                    BULK INSERT " + tableName + @"
                    FROM '" + csvFilePath + @"'
                    WITH (
                        FIELDTERMINATOR = ',',
                        ROWTERMINATOR = '\n',
                        FIRSTROW = 2 -- Skip the first row since it contains headers
                    )";
                    SqlCommand loadDataCommand = new SqlCommand(loadDataQuery, connection);
                    loadDataCommand.ExecuteNonQuery();
                    success = true;
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                MessageBox.Show("Error: " + ex.Message);
            }

            return success;
        }

        public static bool InsertPlannedJoblist(string connectionString, string sourceTableName, int lowerBound, int upperBound)
        {
            bool success = false;
            string query = @"
            INSERT INTO MasterSTXJoblist (JobSequence, SetNumber, PartNumber, JobNumber, ProductCode, ProductName, Date, ISAControl, Status)
            SELECT JobSequence, SetNumber, PartNumber, JobNumber, ProductCode, ProductName, [Date], ISAControl, 'Planned'
            FROM " + sourceTableName + @"
            WHERE JobSequence >= @LowerBound AND JobSequence <= @UpperBound";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LowerBound", lowerBound);
                        command.Parameters.AddWithValue("@UpperBound", upperBound);
                        int rowsAffected = command.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                MessageBox.Show("Error: " + ex.Message);
            }

            return success;
        }

        public static bool UpdateStatusToShipped(string connectionString, string tableName, int lowerBound, int upperBound)
        {
            bool success = false;

            string query = @"
                UPDATE MasterSTXJoblist
                SET Status = 'Shipped'
                WHERE SetNumber IN (SELECT SetNumber FROM " + tableName + @"
                            WHERE JobSequence >= @LowerBound AND JobSequence <= @UpperBound)"; 
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@LowerBound", lowerBound);
                        command.Parameters.AddWithValue("@UpperBound", upperBound);
                        int rowsAffected = command.ExecuteNonQuery();
                        success = rowsAffected > 0;
                    }
                }

            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                MessageBox.Show("Error: " + ex.Message);
            }
            
            return success;
        }
    
    } 
}
