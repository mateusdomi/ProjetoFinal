using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Interfaces
{
    public interface ILoginService
    {
        public bool Criar(Usuario usuario);
    }
}
