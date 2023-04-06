using ProjetoFinal.Models.Notificacoes;

namespace ProjetoFinal.Interfaces
{
    public interface INotificacaoService
    {
        Task<List<Notificacao>> ObterTodasAsync();
        Task<Notificacao> ObterPorIdAsync(int id);
        Task InserirAsync(Notificacao notificacao);
        Task AtualizarAsync(Notificacao notificacao);
        Task RemoverAsync(Notificacao notificacao);
    }

}
