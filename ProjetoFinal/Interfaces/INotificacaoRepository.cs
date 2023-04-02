using ProjetoFinal.Models;
using ProjetoFinal.Models.Notificacoes;

namespace ProjetoFinal.Interfaces
{
    public interface INotificacaoRepository
    {
        Task<Notificacao> ObterPorId(int id);
        Task<IEnumerable<Notificacao>> ObterPorUsuario(int idUsuario);
        Task Inserir(Notificacao notificacao);
        Task Atualizar(Notificacao notificacao);
        Task Excluir(int id);
    }
}
