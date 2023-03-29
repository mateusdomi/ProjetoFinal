using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Models.Logins
{
    public class Login
    {
        public int Id { get; set; } // chave primária
        public int IdUsuario { get; set; } // chave estrangeira
        public Usuario Usuario { get; set; }
        public DateTime Horario { get; set; }
        public string EnderecoIp { get; set; }
    }
}

