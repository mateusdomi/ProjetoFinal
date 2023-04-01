using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Logins
{
    public class Login
    {
        public int Id { get; set; } // chave primária
        public int UsuarioId { get; set; } // chave estrangeira
        public Administrador Usuario { get; set; }
        public DateTime Horario { get; set; }
        public string EnderecoIp { get; set; }
    }
}

