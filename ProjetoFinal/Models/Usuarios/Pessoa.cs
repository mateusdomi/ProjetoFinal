using ProjetoFinal.Models.Usuarios.Enums;

namespace ProjetoFinal.Models.Usuarios
{
    public class Pessoa
    {

        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public string UltimoNome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime Nascimento { get; set; }

        public Pessoa(int pessoaId, string nome, string ultimoNome, string email, string telefone, DateTime nascimento)
        {
            PessoaId = pessoaId;
            Nome = nome;
            UltimoNome = ultimoNome;
            Email = email;
            Telefone = telefone;
            Nascimento = nascimento;
            
        }
    }
}
