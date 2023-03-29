using System.Security.Cryptography;
using System.Text;

namespace ProjetoFinal.Models.Criptografias
{
    public class Criptografia
    {
        public string Criptografar(string texto)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(texto));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }

                return builder.ToString();
            }
        }

        public string CriptografarNomeUsuario(string nomeUsuario)
        {
            return Criptografar(nomeUsuario);
        }

        public string CriptografarSenha(string senha)
        {
            return Criptografar(senha);
        }

        public static bool CompararHashes(string hashString1, string hashString2)
        {
            byte[] hash1 = Convert.FromHexString(hashString1);
            byte[] hash2 = Convert.FromHexString(hashString2);


            if (hash1 == null || hash2 == null || hash1.Length != hash2.Length)
            {
                return false;
            }

            for (int i = 0; i < hash1.Length; i++)
            {
                if (hash1[i] != hash2[i])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
