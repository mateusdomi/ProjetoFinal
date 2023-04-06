using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Logins
{
    public class Login
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; } 
        public Usuario Usuario { get; set; }
        public DateTime Horario { get; set; }
        public string EnderecoIp { get; set; }

        public Login(int id, int usuarioId, Usuario usuario, DateTime horario, string enderecoIp)
        {
            Id = id;
            UsuarioId = usuarioId;
            Usuario = usuario;
            Horario = horario;
            EnderecoIp = enderecoIp;
        }
    }
}

