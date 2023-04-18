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
    public class LoginService: ILoginService
    {
        private readonly ProjetoFinalContext _dbContext;

        public LoginService(ProjetoFinalContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool Criar(Usuario usuario)
        {
            if (VrfUserName(usuario.UserName) == true && VrfEmail(usuario.Email) == true)
            {
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
        public Usuario ObterUserName(string username)
        {
            return _dbContext.Usuario.FirstOrDefault(u => u.UserName.Equals(username));
        }

        public bool EsquiciSenha(string email)
        {
            var usuario = _dbContext.Usuario.FirstOrDefault(u => u.Email.Equals(email));
            if (usuario == null)
            {
                return false;
            }

            var random = new Random().ToString();
            usuario.CodigoRecup = random;

            _dbContext.SaveChanges();

            var mensagem = $"Olá {usuario.UserName}, \n\nPara recuperar sua senha, use o código a seguir: {random}" +
                           "\n\nCaso você não tenha solicitado a recuperação de senha, por favor ignore este e-mail.";

            try
            {
                return EnviarEmail(usuario, "Recuperação de senha", mensagem);
            }
            catch (Exception)
            {
                return false;
            }

        }
        public async Task<bool> RecuperarSenha(string email, string codigoRecup, string newPassword)
        {
            var usuario = await _dbContext.Usuario.FirstOrDefaultAsync(u => u.Email == email && u.CodigoRecup == codigoRecup);
            if (usuario == null)
            {
                return  false;
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
        private bool VrfUserName(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }

            var obj = _dbContext.Usuario.FirstOrDefault(u => u.UserName.Equals(username));

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

            var obj = _dbContext.Usuario.FirstOrDefault(u => u.Email.Equals(email));

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
    }
}
