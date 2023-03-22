using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjetoFinal.Infra
{


    public class LogAtividadeRepository : ILogAtividadeRepository
    {
        private readonly string _connectionString;

        public LogAtividadeRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<LogAtividade>> GetLogAtividadesAsync()
        {
            var logAtividades = new List<LogAtividade>();

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("SELECT Id, IdUsuario, DataHora, Descricao FROM LogAtividade", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            var logAtividade = new LogAtividade
                            {
                                Id = (int)reader["Id"],
                                IdUsuario = (int)reader["IdUsuario"],
                                DataHora = (DateTime)reader["DataHora"],
                                Descricao = (string)reader["Descricao"]
                            };

                            logAtividades.Add(logAtividade);
                        }
                    }
                }
            }

            return logAtividades;
        }

        public async Task<LogAtividade> GetLogAtividadeByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("SELECT Id, IdUsuario, DataHora, Descricao FROM LogAtividade WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            var logAtividade = new LogAtividade
                            {
                                Id = (int)reader["Id"],
                                IdUsuario = (int)reader["IdUsuario"],
                                DataHora = (DateTime)reader["DataHora"],
                                Descricao = (string)reader["Descricao"]
                            };

                            return logAtividade;
                        }
                    }
                }
            }

            return null;
        }

        public async Task CreateLogAtividadeAsync(LogAtividade logAtividade)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (var command = new SqlCommand("INSERT INTO LogAtividade (IdUsuario, DataHora, Descricao) VALUES (@IdUsuario, @DataHora, @Descricao)", connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", logAtividade.IdUsuario);
                    command.Parameters.AddWithValue("@DataHora", logAtividade.DataHora);
                    command.Parameters.AddWithValue("@Descricao", logAtividade.Descricao);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateLogAtividadeAsync(LogAtividade logAtividade)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("UPDATE LogAtividade SET IdUsuario = @IdUsuario, DataHora = @DataHora, Descricao = @Descricao WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", logAtividade.IdUsuario);
                    command.Parameters.AddWithValue("@DataHora", logAtividade.DataHora);
                    command.Parameters.AddWithValue("@Descricao", logAtividade.Descricao);
                    command.Parameters.AddWithValue("@Id", logAtividade.Id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteLogAtividadeAsync(int id)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                using (SqlCommand command = new SqlCommand("DELETE FROM LogAtividade WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);

                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
