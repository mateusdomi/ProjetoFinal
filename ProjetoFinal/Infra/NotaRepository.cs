using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using System.Data.SqlClient;

namespace ProjetoFinal.Services
{
    public class NotaRepository : INotaRepository
    {
        private readonly string _connectionString;

        public NotaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Nota> ObterPorId(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT * FROM Notas WHERE Id = @Id";
                var parametros = new { Id = id };
                var nota = await connection.QueryFirstOrDefaultAsync<Nota>(sql, parametros);

                return nota;
            }
        }

        public async Task<IEnumerable<Nota>> ObterPorAvaliacao(int idAvaliacao)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT * FROM Notas WHERE IdAvaliacao = @IdAvaliacao";
                var parametros = new { IdAvaliacao = idAvaliacao };
                var notas = await connection.QueryAsync<Nota>(sql, parametros);

                return notas;
            }
        }

        public async Task<IEnumerable<Nota>> ObterPorAluno(int idAluno)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "SELECT * FROM Notas WHERE IdAluno = @IdAluno";
                var parametros = new { IdAluno = idAluno };
                var notas = await connection.QueryAsync<Nota>(sql, parametros);

                return notas;
            }
        }

        public async Task Inserir(Nota nota)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "INSERT INTO Notas (IdAluno, IdAvaliacao, Nota) VALUES (@IdAluno, @IdAvaliacao, @Nota)";
                var parametros = new { IdAluno = nota.IdAluno, IdAvaliacao = nota.IdAvaliacao, Nota = nota.NotaValor };
                await connection.ExecuteAsync(sql, parametros);
            }
        }

        public async Task Atualizar(Nota nota)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "UPDATE Notas SET Nota = @Nota WHERE Id = @Id";
                var parametros = new { Id = nota.Id, Nota = nota.NotaValor };
                await connection.ExecuteAsync(sql, parametros);
            }
        }

        public async Task Excluir(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                var sql = "DELETE FROM Notas WHERE Id = @Id";
                var parametros = new { Id = id };
                await connection.ExecuteAsync(sql, parametros);
            }
        }
    }
}