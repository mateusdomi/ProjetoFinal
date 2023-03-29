using ProjetoFinal.Connection;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using ProjetoFinal.Models.Usuarios;
using System.Data.SqlClient;

namespace ProjetoFinal.Services
{
    public class UsuarioRepository : IUsuarioRepository
    {

        public async Task<Usuario> Autenticar(string email, string senha)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var command = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email AND Senha = @Senha", connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Senha", senha);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"],
                        Email = (string)reader["Email"],
                        Senha = (string)reader["Senha"]
                    };
                }

                return null;
            }
        }

        public async Task<Usuario> ObterPorId(int id)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var command = new SqlCommand("SELECT * FROM Usuarios WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"],
                        Email = (string)reader["Email"],
                        Senha = (string)reader["Senha"]
                    };
                }

                return null;
            }
        }

        public async Task<Usuario> ObterPorEmail(string email)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var command = new SqlCommand("SELECT * FROM Usuarios WHERE Email = @Email", connection);
                command.Parameters.AddWithValue("@Email", email);

                var reader = await command.ExecuteReaderAsync();

                if (await reader.ReadAsync())
                {
                    return new Usuario
                    {
                        Id = (int)reader["Id"],
                        Nome = (string)reader["Nome"],
                        Email = (string)reader["Email"],
                        Senha = (string)reader["Senha"]
                    };
                }

                return null;
            }
        }

        public async Task Inserir(Usuario usuario)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var command = new SqlCommand("INSERT INTO Usuarios (Nome, Email, Senha) VALUES (@Nome, @Email, @Senha)", connection);
                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task Atualizar(Usuario usuario)
        {
            using (var connection = await Conexao.AbrirAsync())
            {
                var command = new SqlCommand("UPDATE Usuarios SET Nome = @Nome, Email = @Email, Senha = @Senha WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", usuario.Id);
                command.Parameters.AddWithValue("@Nome", usuario.Nome);
                command.Parameters.AddWithValue("@Email", usuario.Email);
                command.Parameters.AddWithValue("@Senha", usuario.Senha);

                await command.ExecuteNonQueryAsync();
            }
        }

        public async Task Excluir(int id)
        {
            using (var connection = await Conexao.AbrirAsync())
            {

                var command = new SqlCommand("DELETE FROM Usuarios WHERE Id = @Id", connection);
                command.Parameters.AddWithValue("@Id", id);


                await command.ExecuteNonQueryAsync();
            }
        }
    }
}

