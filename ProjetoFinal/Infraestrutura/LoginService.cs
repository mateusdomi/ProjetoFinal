using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Data;
using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Notificacoes;
using ProjetoFinal.Models.Usuarios;
using System.Security.Cryptography;
using System.Text;

namespace ProjetoFinal.Infraestrutura
{
    public class LoginService : ILoginService
    {
        private readonly ProjetoFinalContext _dbContext;

        public LoginService(ProjetoFinalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Criar(Usuario usuario)
        {
            if (VrfUserName(usuario.UserName) == true && VrfEmail(usuario.Email) == true && usuario.Password != null)
            {
                usuario.CreateAt = DateTime.Now;
                var passwordHash = HashPass(usuario.Password);
                usuario.Password = passwordHash;
                _dbContext.Usuario.Add(usuario);
                EnviarEmail(usuario, $"Seja Bem-vindo(a) {usuario.UserName}", "Seja Bem-vinda a maior rede escolar do Brasil");
                _dbContext.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Login(string username, string password)
        {
            var usuario = _dbContext.Usuario.Where(u => u.UserName.Equals(username)).FirstOrDefault();
            if (usuario == null)
                return false;

            var passhash = HashPass(password);

            if (passhash.Equals(usuario.Password))
                return true;

            return false;
        }

        public bool EsqueciSenha(string email)
        {
            var usuario = _dbContext.Usuario.FirstOrDefault(u => u.Email.Equals(email));
            if (usuario == null)
            {
                return false;
            }

            var random = GeradorCodigo();
            usuario.CodigoRecup = random;

            _dbContext.SaveChanges();

            var mensagem = $"Olá {usuario.UserName}, \n\nPara recuperar sua senha, use o código a seguir: {usuario.CodigoRecup}" +
                           "\n\nCaso você não tenha solicitado a recuperação de senha, por favor ignore este e-mail.";

            try
            {
                return EnviarEmail(usuario, "Nova Senha", mensagem);
            }
            catch (Exception)
            {
                return false;
            }

        }

        private string GeradorCodigo()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var random = new Random();
            var result = new StringBuilder(5);
            for (int i = 0; i < 5; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }
            return result.ToString();
        }

        public async Task<bool> RecuperarSenha(string email, string codigoRecup, string newPassword)
        {
            var usuario = await _dbContext.Usuario.FirstOrDefaultAsync(u => u.Email == email && u.CodigoRecup == codigoRecup);
            if (usuario == null)
            {
                return false;
            }
            usuario.Password = HashPass(newPassword);
            usuario.CodigoRecup = "";
            await _dbContext.SaveChangesAsync();


            return true;

        }

        public bool VrfSenha(Usuario usuario, string passwd)
        {
            var passdHash = HashPass(passwd);
            return usuario.Password.Equals(passdHash);
        }

        public string VrfCodigo(string CodigoRecup)
        {
            if (!string.IsNullOrEmpty(CodigoRecup))
            {
                var obj = _dbContext.Usuario.Where(u => u.CodigoRecup.Equals(CodigoRecup)).FirstOrDefault();

                if (obj == null)
                    throw new InvalidOperationException("Codigo Invalido!");
                return obj.UserName;

            }
            throw new InvalidOperationException("Codigo Invalido!");
        }

        private bool VrfUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            var obj = _dbContext.Usuario.Where(u => u.UserName.Equals(username)).FirstOrDefault();

            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool VrfEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }

            var obj = _dbContext.Usuario.Where(u => u.Email.Equals(email)).FirstOrDefault();

            if (obj == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private string HashPass(string passw)
        {
            using var sha256 = SHA256.Create();
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(passw));
            return Convert.ToBase64String(hashedBytes);
        }

        private static string Base64UrlEncode(string input)
        {
            var inputBytes = Encoding.UTF8.GetBytes(input);
            return Convert.ToBase64String(inputBytes)
              .Replace('+', '-')
              .Replace('/', '_')
              .Replace("=", "");
        }
        private bool EnviarEmail(Usuario usuario, string assunto, string mensagem)
        {
            try
            {
                // Autenticação
                UserCredential credential;
                using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
                {
                    string credPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                    credPath = Path.Combine(credPath, ".credentials/gmail-dotnet-quickstart.json");

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.FromStream(stream).Secrets,
                        new[] { GmailService.Scope.GmailSend },
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                // Criação do serviço
                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = "Gmail API"
                });

                // Criação da mensagem
                var message = new Google.Apis.Gmail.v1.Data.Message();
                message.Raw = Base64UrlEncode("From: avaliacao.escolar.digital@gmail.com\r\n" +
                                              $"To: {usuario.Email}\r\n" +
                                              $"Subject: {assunto}\r\n\r\n" +
                                              $"{mensagem}");

                // Envio da mensagem
                service.Users.Messages.Send(message, "me").Execute();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MudarSenha(string senha, string username)
        {

            var user = _dbContext.Usuario.Where(u => u.UserName.Equals(username)).FirstOrDefault();
            if (user != null)
            {

                user.Password = HashPass(senha);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
