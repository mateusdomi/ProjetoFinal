using Dapper;
using ProjetoFinal.Connection;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Models.Avaliacoes;
using System.Data.SqlClient;

namespace ProjetoFinal.Services
{
    public class AvaliacaoRepository : IAvaliacaoRepository
    {
        private readonly string _connectionString;

        public AvaliacaoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Avaliacao> ObterPorId(int id)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var query = "SELECT * FROM Avaliacoes WHERE Id = @Id";
                var parameters = new { Id = id };
                var result = await connection.QuerySingleOrDefaultAsync<Avaliacao>(query, parameters);
                return result;
            }
        }

        public async Task<IEnumerable<Avaliacao>> ObterPorTurma(int idTurma)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var query = "SELECT * FROM Avaliacoes WHERE TurmaId = @TurmaId";
                var parameters = new { TurmaId = idTurma };
                var result = await connection.QueryAsync<Avaliacao>(query, parameters);
                return result;
            }
        }

        public async Task<IEnumerable<Avaliacao>> ObterPorDisciplina(int idDisciplina)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var query = "SELECT * FROM Avaliacoes WHERE DisciplinaId = @DisciplinaId";
                var parameters = new { DisciplinaId = idDisciplina };
                var result = await connection.QueryAsync<Avaliacao>(query, parameters);
                return result;
            }
        }

        public async Task<IEnumerable<Avaliacao>> ObterPorProfessor(int idProfessor)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var query = "SELECT * FROM Avaliacoes WHERE ProfessorId = @ProfessorId";
                var parameters = new { ProfessorId = idProfessor };
                var result = await connection.QueryAsync<Avaliacao>(query, parameters);
                return result;
            }
        }

        public async Task Inserir(Avaliacao avaliacao)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var query = "INSERT INTO Avaliacoes (Descricao, Data, TurmaId, DisciplinaId, ProfessorId) " +
                            "VALUES (@Descricao, @Data, @TurmaId, @DisciplinaId, @ProfessorId)";
                await connection.ExecuteAsync(query, avaliacao);
            }
        }

        public async Task Atualizar(Avaliacao avaliacao)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var query = "UPDATE Avaliacoes SET Descricao = @Descricao, Data = @Data, TurmaId = @TurmaId, " +
                            "DisciplinaId = @DisciplinaId, ProfessorId = @ProfessorId WHERE Id = @Id";
                await connection.ExecuteAsync(query, avaliacao);
            }
        }

        public async Task Excluir(int id)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var query = "DELETE FROM Avaliacoes WHERE Id = @Id";
                var parameters = new { Id = id };
                await connection.ExecuteAsync(query, parameters);
            }
        }
    }
}
