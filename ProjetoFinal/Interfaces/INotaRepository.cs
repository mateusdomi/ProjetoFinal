using ProjetoFinal.Models;

namespace ProjetoFinal.Interfaces
{
    public interface INotaRepository
    {
        Task<Nota> ObterPorId(int id);
        Task<IEnumerable<Nota>> ObterPorAvaliacao(int idAvaliacao);
        Task<IEnumerable<Nota>> ObterPorAluno(int idAluno);
        Task Inserir(Nota nota);
        Task Atualizar(Nota nota);
        Task Excluir(int id);
    }
}
