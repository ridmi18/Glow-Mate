using System;
using System.Data;
using System.Data.SqlClient;

namespace GlowMate
{
    /// <summary>
    /// Provides simplified methods for database operations such as querying, non-query, and scalar execution.
    /// </summary>
    public class DatabaseConnector
    {
        private readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=GlowMate;Integrated Security=True";

        /// <summary>
        /// Executes a SELECT query and returns a DataTable.
        /// </summary>
        public DataTable ExecuteQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            DataTable result = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = commandType;

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(result);
                }
            }

            return result;
        }

        /// <summary>
        /// Convenience method for SELECT queries with default CommandType.Text.
        /// </summary>
        public DataTable GetData(string query)
        {
            return ExecuteQuery(query);
        }

        /// <summary>
        /// Executes INSERT, UPDATE, or DELETE commands. Returns the number of rows affected.
        /// </summary>
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            int rowsAffected;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = commandType;

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                rowsAffected = command.ExecuteNonQuery();
            }

            return rowsAffected;
        }

        /// <summary>
        /// Executes a query that returns a single value.
        /// </summary>
        public object ExecuteScalar(string query, SqlParameter[] parameters = null, CommandType commandType = CommandType.Text)
        {
            object result;

            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.CommandType = commandType;

                if (parameters != null)
                    command.Parameters.AddRange(parameters);

                connection.Open();
                result = command.ExecuteScalar();
            }

            return result;
        }
    }
}
