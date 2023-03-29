using ProjetoFinal.Models;
using ProjetoFinal.Models.Disciplinas;

namespace ProjetoFinal.Interfaces
{
    public interface IDisciplinaRepository
    {
        Task<Disciplina> ObterPorId(int id);
        Task<IEnumerable<Disciplina>> ObterPorProfessor(int idProfessor);
        Task Inserir(Disciplina disciplina);
        Task Atualizar(Disciplina disciplina);
        Task Excluir(int id);

    }
}
