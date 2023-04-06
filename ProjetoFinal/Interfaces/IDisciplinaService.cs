using ProjetoFinal.Models;
using ProjetoFinal.Models.Disciplinas;

namespace ProjetoFinal.Interfaces
{
    public interface IDisciplinaService
    {
        Task<List<Disciplina>> ListarTodasDisciplinas();
        Task<Disciplina> BuscarDisciplina(int id);
        Task InserirDisciplina(Disciplina disciplina);
        Task AtualizarDisciplina(Disciplina disciplina);
        Task ExcluirDisciplina(int id);
        Task<bool> DisciplinaExists(int id);
    }
}
