using ProjetoFinal.Connection;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Models.Disciplinas;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjetoFinal.Services
{

    public class DisciplinaRepository : IDisciplinaRepository
    {
        private readonly string _connectionString;

        public DisciplinaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<Disciplina> ObterPorId(int id)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                using (var command = new SqlCommand("SELECT Id, Nome, ProfessorId FROM Disciplina WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Disciplina
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                IdProfessor = reader.GetInt32(2)
                            };
                        }

                        return null;
                    }
                }
            }
        }

        public async Task<IEnumerable<Disciplina>> ObterPorProfessor(int idProfessor)
        {
            var disciplinas = new List<Disciplina>();

            using (var connection = await Conexao.AbrirAsync())
            {
                using (var command = new SqlCommand("SELECT Id, Nome, ProfessorId FROM Disciplina WHERE ProfessorId = @ProfessorId", connection))
                {
                    command.Parameters.AddWithValue("@ProfessorId", idProfessor);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            disciplinas.Add(new Disciplina
                            {
                                Id = reader.GetInt32(0),
                                Nome = reader.GetString(1),
                                IdProfessor = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }

            return disciplinas;
        }

        public async Task Inserir(Disciplina disciplina)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                using (var command = new SqlCommand("INSERT INTO Disciplina (Nome, ProfessorId) VALUES (@Nome, @ProfessorId)", connection))
                {
                    command.Parameters.AddWithValue("@Nome", disciplina.Nome);
                    command.Parameters.AddWithValue("@ProfessorId", disciplina.IdProfessor);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Atualizar(Disciplina disciplina)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                using (var command = new SqlCommand("UPDATE Disciplina SET Nome = @Nome, ProfessorId = @ProfessorId WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", disciplina.Id);
                    command.Parameters.AddWithValue("@Nome", disciplina.Nome);
                    command.Parameters.AddWithValue("@ProfessorId", disciplina.IdProfessor);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Excluir(int id)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                using (var command = new SqlCommand("DELETE FROM Disciplina WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }

}
