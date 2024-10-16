using System.Data;
using System.Data.SqlClient;

namespace GISSA.Models
{
    public class App_DB_Context
    {
        private readonly string _connectionString;



        // Constructor que obtiene el connection string del appsettings.json
        public App_DB_Context(IConfiguration configuration) 
        { 
            _connectionString = configuration.GetConnectionString("SQLSERVERConnection"); 
        }

        // Método para ejecutar un procedimiento que no devuelve datos (INSERT, UPDATE, DELETE)
        public int ExecuteNonQuery(string storedProcedure, SqlParameter[]? parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);
                    return command.ExecuteNonQuery(); // Devuelve el número de filas afectadas
                }
            }
        }

        // Método para ejecutar un procedimiento y devolver datos en un DataTable
        public DataTable ExecuteReader(string storedProcedure, SqlParameter[]? parameters = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(storedProcedure, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    if (parameters != null)
                        command.Parameters.AddRange(parameters);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();
                        table.Load(reader); // Carga los resultados en un DataTable
                        return table;
                    }
                }
            }
        }


    }
}
