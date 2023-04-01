using ProjetoFinal.Models;
using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Administrador> Autenticar(string email, string senha);
        Task<Administrador> ObterPorId(int id);
        Task<Administrador> ObterPorEmail(string email);
        Task Inserir(Administrador usuario);
        Task Atualizar(Administrador usuario);
        Task Excluir(int id);
    }

}
