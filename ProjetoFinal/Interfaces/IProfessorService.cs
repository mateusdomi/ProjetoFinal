using ProjetoFinal.Models.Usuarios;

namespace ProjetoFinal.Interfaces
{
    public interface IProfessorService
    {
        Task<List<Professor>> ObterTodosAsync();
        Task<Professor> ObterPorIdAsync(int id);
        Task InserirAsync(Professor professor);
        Task AtualizarAsync(Professor professor);
        Task RemoverAsync(Professor professor);
    }
}
