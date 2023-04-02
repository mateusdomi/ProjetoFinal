using System.Data.SqlClient;
using System.Data;

namespace ProjetoFinal.Connection
{
    public class Conexao
    {
        private static readonly string connectionString = @"Data Source=DAMAZIO\\SQLEXPRESS; Initial Catalog=dbProjetoFinal; Integrated Security=True";

        public static async Task<SqlConnection> AbrirAsync()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }

        public static async Task FecharAsync(SqlConnection connection)
        {
            if (connection != null && connection.State == ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
        }
    }
}
