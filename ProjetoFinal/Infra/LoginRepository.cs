using ProjetoFinal.Connection;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoFinal.Infra
{

    public class LoginRepository : ILoginRepository
    {
        public async Task<Login> SaveLoginAsync(Login login)
        {
            // Criptografa a senha
            using (var sha256 = SHA256.Create())
            {
                var hashedPassword = sha256.ComputeHash(Encoding.UTF8.GetBytes(login.Usuario.Senha));
                login.Usuario.Senha = Convert.ToBase64String(hashedPassword);
            }

            // Salva o login no banco de dados
            using (var connection = await Conexao.AbrirAsync())
            {
              
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = @"
                    INSERT INTO Logins (IdUsuario, Horario, EnderecoIp)
                    VALUES (@IdUsuario, @Horario, @EnderecoIp);
                    SELECT SCOPE_IDENTITY();
                ";
                    command.Parameters.AddWithValue("@IdUsuario", login.IdUsuario);
                    command.Parameters.AddWithValue("@Horario", login.Horario);
                    command.Parameters.AddWithValue("@EnderecoIp", login.EnderecoIp);
                    login.Id = (int)await command.ExecuteScalarAsync();
                }
            }

            return login;
        }

        public bool VerifyPassword(string plainTextPassword, string hashedPassword)
        {
            using (var sha256 = SHA256.Create())
            {
                var computedHash = sha256.ComputeHash(Encoding.UTF8.GetBytes(plainTextPassword));
                var computedHashString = Convert.ToBase64String(computedHash);
                return computedHashString == hashedPassword;
            }
        }
    }


}
