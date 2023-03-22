using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface ITurmaRepository
    {
        Task<Turma> ObterPorId(int id);
        Task<IEnumerable<Turma>> ObterPorProfessor(int idProfessor);
        Task Inserir(Turma turma);
        Task Atualizar(Turma turma);
        Task Excluir(int id);
    }
}
