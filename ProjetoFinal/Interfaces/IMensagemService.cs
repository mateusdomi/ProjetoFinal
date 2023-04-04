using ProjetoFinal.Models.Notificacoes;

namespace ProjetoFinal.Interfaces
{
    public interface IMensagemService
    {
        Task<List<Mensagem>> ObterTodasAsync();
        Task<Mensagem> ObterPorIdAsync(int id);
        Task InserirAsync(Mensagem mensagem);
        Task AtualizarAsync(Mensagem mensagem);
        Task RemoverAsync(Mensagem mensagem);
    }
}
