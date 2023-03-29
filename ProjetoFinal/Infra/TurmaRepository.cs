using ProjetoFinal.Connection;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Models.Turmas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{

    public class TurmaRepository : ITurmaRepository
    {
        
        
        public async Task<Turma> ObterPorId(int id)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var sql = "SELECT * FROM Turma WHERE Id = @Id";
                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();

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

            using (var connection = await Conexao.AbrirAsync())
            {
                var sql = "SELECT * FROM Turma WHERE IdProfessor = @IdProfessor";
                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@IdProfessor", idProfessor);

                await connection.OpenAsync();

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
            using (var connection = await Conexao.AbrirAsync())
            {
                var sql = "INSERT INTO Turma (Nome, IdProfessor) VALUES (@Nome, @IdProfessor)";
                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Nome", turma.Nome);
                //cmd.Parameters.AddWithValue("@IdProfessor", turma.IdProfessor);

                await connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task Atualizar(Turma turma)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var sql = "UPDATE Turma SET Nome = @Nome WHERE Id = @Id";
                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Nome", turma.Nome);
                
                cmd.Parameters.AddWithValue("@Id", turma.Id);

                await connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        public async Task Excluir(int id)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var sql = "DELETE FROM Turma WHERE Id = @Id";
                var cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@Id", id);

                await connection.OpenAsync();
                await cmd.ExecuteNonQueryAsync();
            }
        }

        private Turma MapToTurma(SqlDataReader reader)
        {
            return new Turma
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nome = reader["Nome"].ToString(),
            };
        }
    }

}
