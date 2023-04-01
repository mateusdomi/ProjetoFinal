using ProjetoFinal.Models.Avaliacoes;

namespace ProjetoFinal.Interfaces
{
    public interface INotaRepository
    {
        Task<Avaliacao> ObterPorId(int id);
        Task<IEnumerable<Avaliacao>> ObterPorAvaliacao(int idAvaliacao);
        Task<IEnumerable<Avaliacao>> ObterPorAluno(int idAluno);
        Task Inserir(Avaliacao nota);
        Task Atualizar(Avaliacao nota);
        Task Excluir(int id);
    }
}
