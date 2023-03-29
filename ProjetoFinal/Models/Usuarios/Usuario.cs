using ProjetoFinal.Models.Usuarios.Enums;
using ProjetoFinal.Models.Usuarios.Funcao;

namespace ProjetoFinal.Models.Usuarios
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Perfil Perfil { get; set; }
        public Atividade_Usuario Ativo { get; set; }
        public FuncaoUsuario Funcao { get; set; }
        public Usuario()
        {
        }
        public Usuario(int id, string nome, string email, string senha, Perfil perfil, Atividade_Usuario ativo, FuncaoUsuario funcaoUsuario)
        {
            Id = id;
            Nome = nome;
            Email = email;
            Senha = senha;
            Perfil = perfil;
            Ativo = ativo;
            Funcao = funcaoUsuario;
        }
    }
}
