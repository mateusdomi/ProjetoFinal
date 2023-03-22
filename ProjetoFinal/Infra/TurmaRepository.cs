using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{
  
    public class TurmaRepository : ITurmaRepository
    {
        private readonly string _connectionString;

        public TurmaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Turma> ObterPorId(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Turma WHERE Id = @Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return MapToTurma(reader);
                    }
                    return null;
                }
            }
        }

        public async Task<IEnumerable<Turma>> ObterPorProfessor(int idProfessor)
        {
            var turmas = new List<Turma>();

            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "SELECT * FROM Turma WHERE IdProfessor = @IdProfessor";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@IdProfessor", idProfessor);

                await conn.OpenAsync();

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        turmas.Add(MapToTurma(reader));
                    }
                }
            }

            return turmas;
        }

        public async Task Inserir(Turma turma)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "INSERT INTO Turma (Nome, IdProfessor) VALUES (@Nome, @IdProfessor)";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", turma.Nome);
                cmd.Parameters.AddWithValue("@IdProfessor", turma.IdProfessor);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task Atualizar(Turma turma)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "UPDATE Turma SET Nome = @Nome, IdProfessor = @IdProfessor WHERE Id = @Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Nome", turma.Nome);
                cmd.Parameters.AddWithValue("@IdProfessor", turma.IdProfessor);
                cmd.Parameters.AddWithValue("@Id", turma.Id);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task Excluir(int id)
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                var sql = "DELETE FROM Turma WHERE Id = @Id";
                var cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                await conn.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private Turma MapToTurma(SqlDataReader reader)
        {
            return new Turma
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
                IdProfessor = Convert.ToInt32(reader["IdProfessor"])
            };
        }
    }

}
