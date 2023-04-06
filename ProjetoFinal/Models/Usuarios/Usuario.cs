using ProjetoFinal.Models.Usuarios.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public Usuario(int id, string userName, string email, string password, DateTime create, Atividade atividade, int pessoaId, Pessoa pessoa)
        {
            UsuarioId = id;
            UserName = userName;
            Email = email;
            Password = password;
            CreateAt = create;
            Atividade = atividade;
            PessoaId = pessoaId;
            Pessoa = pessoa;
        }
    }
}
