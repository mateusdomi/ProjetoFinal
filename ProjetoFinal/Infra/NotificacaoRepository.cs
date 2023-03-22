using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProjetoFinal.Infra
{
    public class NotificacaoRepository : INotificacaoRepository
    {
        private readonly string connectionString;

        public NotificacaoRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public async Task<Notificacao> ObterPorId(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Notificacoes WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            return new Notificacao
                            {
                                Id = (int)reader["Id"],
                                Mensagem = reader["Mensagem"].ToString(),
                                Data = (DateTime)reader["Data"],
                                IdUsuario = (int)reader["IdUsuario"]
                            };
                        }
                    }
                }
            }

            return null;
        }

        public async Task<IEnumerable<Notificacao>> ObterPorUsuario(int idUsuario)
        {
            var notificacoes = new List<Notificacao>();

            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("SELECT * FROM Notificacoes WHERE IdUsuario = @IdUsuario", connection))
                {
                    command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            notificacoes.Add(new Notificacao
                            {
                                Id = (int)reader["Id"],
                                Mensagem = reader["Mensagem"].ToString(),
                                Data = (DateTime)reader["Data"],
                                IdUsuario = (int)reader["IdUsuario"]
                            });
                        }
                    }
                }
            }

            return notificacoes;
        }

        public async Task Inserir(Notificacao notificacao)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("INSERT INTO Notificacoes (Mensagem, Data, IdUsuario) VALUES (@Mensagem, @Data, @IdUsuario)", connection))
                {
                    command.Parameters.AddWithValue("@Mensagem", notificacao.Mensagem);
                    command.Parameters.AddWithValue("@Data", notificacao.Data);
                    command.Parameters.AddWithValue("@IdUsuario", notificacao.IdUsuario);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Atualizar(Notificacao notificacao)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("UPDATE Notificacoes SET Mensagem = @Mensagem, Data = @Data, IdUsuario = @IdUsuario WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", notificacao.Id);
                    command.Parameters.AddWithValue("@Mensagem", notificacao.Mensagem);
                    command.Parameters.AddWithValue("@Data", notificacao.Data);
                    command.Parameters.AddWithValue("@IdUsuario", notificacao.IdUsuario);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task Excluir(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlCommand("DELETE FROM Notificacoes WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }
    }
}