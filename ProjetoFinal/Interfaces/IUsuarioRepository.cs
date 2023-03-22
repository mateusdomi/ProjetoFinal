using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> Autenticar(string email, string senha);
        Task<Usuario> ObterPorId(int id);
        Task<Usuario> ObterPorEmail(string email);
        Task Inserir(Usuario usuario);
        Task Atualizar(Usuario usuario);
        Task Excluir(int id);
    }

}
