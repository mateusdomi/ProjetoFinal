using ProjetoFinal.Models.Turmas;

namespace ProjetoFinal.Interfaces
{
    public interface ITurmaService
    {
        Task<List<Turma>> ObterTodosAsync();
        Task<Turma> ObterPorIdAsync(int id);
        Task InserirAsync(Turma turma);
        Task AtualizarAsync(Turma turma);
        Task RemoverAsync(Turma turma);
    }
}
