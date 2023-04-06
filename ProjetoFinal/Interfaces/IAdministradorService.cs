using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Interfaces
{
    public interface IAdministradorService 
    {
        Task<List<Administrador>> ObterTodosAsync();
        Task<Administrador> ObterPorIdAsync(int id);
        Task InserirAsync(Administrador administrador);
        Task AtualizarAsync(Administrador administrador);
        Task RemoverAsync(Administrador administrador);
    }
}
