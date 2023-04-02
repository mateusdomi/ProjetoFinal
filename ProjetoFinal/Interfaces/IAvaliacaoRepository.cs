using ProjetoFinal.Models;
using ProjetoFinal.Models.Avaliacoes;

namespace ProjetoFinal.Interfaces
{
    public interface IAvaliacaoRepository
    {
        Task<Avaliacao> ObterPorId(int id);
        Task<IEnumerable<Avaliacao>> ObterPorTurma(int idTurma);
        Task<IEnumerable<Avaliacao>> ObterPorDisciplina(int idDisciplina);
        Task<IEnumerable<Avaliacao>> ObterPorProfessor(int idProfessor);
        Task Inserir(Avaliacao avaliacao);
        Task Atualizar(Avaliacao avaliacao);
        Task Excluir(int id);
    }

}
