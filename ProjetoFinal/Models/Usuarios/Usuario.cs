using ProjetoFinal.Models.Usuarios.Enums;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Atividade Atividade { get; set; }


        public Usuario()
        {

        }
        public Usuario(int id, string nome, string email, string senha, Atividade atividade)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Atividade = atividade;
        }
    }
}
