using ProjetoFinal.Models.Usuarios.Enums;

namespace ProjetoFinal.Models.Usuarios
{
    public class Administrador
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
    }
}
