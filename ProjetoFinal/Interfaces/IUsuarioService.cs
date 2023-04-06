using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ObterTodosAsync();
        Task<Usuario> ObterPorIdAsync(int id);
        Task InserirAsync(Usuario usuario);
        Task AtualizarAsync(Usuario usuario);
        Task RemoverAsync(Usuario usuario);
    }
}
