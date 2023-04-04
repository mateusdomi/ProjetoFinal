using ProjetoFinal.Models.Historicos;

namespace ProjetoFinal.Interfaces
{
    public interface IHistoricoService
    {
        Task<List<Historico>> ListarHistorico();
        Task<Historico> BuscarHistorico(int id);
        Task<List<Historico>> FiltrarHistoricoPorAluno(int alunoId);
        Task InserirHistorico(Historico historico);
        Task AtualizarHistorico(Historico historico);
        Task ExcluirHistorico(int id);
        Task<bool> HistoricoExists(int id);
    }
}
