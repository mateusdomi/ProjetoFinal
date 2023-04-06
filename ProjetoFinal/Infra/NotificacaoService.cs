using ProjetoFinal.Interfaces;
using ProjetoFinal.Models.Notificacoes;

namespace ProjetoFinal.Infra
{
    public class NotificacaoService : INotificacaoService
    {
        private readonly MeuDbContext _context;

        public NotificacaoService(MeuDbContext context)
        {
            _context = context;
        }

        public async Task<List<Notificacao>> ObterTodasAsync()
        {
            return await _context.ObterTodasAsync();
        }

        public async Task<Notificacao> ObterPorIdAsync(int id)
        {
            return await _context.ObterPorIdAsync(id);
        }

        public async Task InserirAsync(Notificacao notificacao)
        {
            await _context.InserirAsync(notificacao);
        }

        public async Task AtualizarAsync(Notificacao notificacao)
        {
            await _context.AtualizarAsync(notificacao);
        }

        public async Task RemoverAsync(Notificacao notificacao)
        {
            await _context.RemoverAsync(notificacao);
        }
    }

}
