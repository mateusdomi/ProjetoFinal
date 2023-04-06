using ProjetoFinal.Models.Usuarios.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models.Usuarios
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
        public Atividade Atividade { get; set; }
        public int? PessoaId { get; set; }
        public Pessoa? Pessoa { get; set; }



        public Usuario()
        {

        }

        public Usuario(int usuarioId, string userName, string email, string password, DateTime createAt, Atividade atividade, int? pessoaId, Pessoa? pessoa)
        {
            UsuarioId = usuarioId;
            UserName = userName;
            Email = email;
            Password = password;
            CreateAt = createAt;
            Atividade = atividade;
            PessoaId = pessoaId;
            Pessoa = pessoa;
        }
    }
}
